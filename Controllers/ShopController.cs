using McIntashLaptops.Areas.Identity.Data;
using McIntashLaptops.Models;
using McIntashLaptops.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Stripe;
using Stripe.Checkout;
using System.Drawing.Text;
using System.Security.Claims;
using System.Security.Policy;


namespace McIntashLaptops.Controllers
{
    [Authorize]
    public class ShopController : Controller
    {
        ILaptopDataService laptopDAO;
        static ShoppingCartService shoppingCartService = new ShoppingCartService();
        UserManager<ApplicationUser> userManager;
        public ShopController(ILaptopDataService dataService, UserManager<ApplicationUser> _userManager)
        {
            laptopDAO = dataService;
            userManager = _userManager;
        }

        public IActionResult Index()
        {
            return View("Index",laptopDAO.All());
        }
        public IActionResult SearchResults(string searchTerm)
        {
            return View("Index",laptopDAO.SearchLaptops(searchTerm));
        }

        public IActionResult Cart()
        {
            shoppingCartService.calculateTotal();
            return View("Cart", shoppingCartService.ShoppingCart);
        }

        public JsonResult AddToCart(int id)
        {
            LaptopModelDTO oneItem =  shoppingCartService.Add(id);
            return Json(oneItem);
        }

        public IActionResult AddOneToCart(int id)
        {
            LaptopModelDTO oneItem = shoppingCartService.Add(id);
            return PartialView("_laptopRowDTO", oneItem);
        }

        public IActionResult RemoveFromCart(int id)
        {
            LaptopModelDTO oneItem = shoppingCartService.Remove(id);
            return PartialView("_laptopRowDTO",oneItem);
        }

        public IActionResult ShowOneLaptop(int Id)
        {
            return View(laptopDAO.GetLaptopById(Id));
        }

        public JsonResult getTotalJson()
        {

            var total = shoppingCartService.getTotal();
            return Json(total);
        }

        public async Task<ActionResult> checkout(CheckoutModel model)
        {
            ApplicationUser user = await userManager.FindByNameAsync(User.Identity.Name);

            if(shoppingCartService.ShoppingCart.Count>0&&ModelState.IsValid)
            {
                var domain = "https://localhost:7085/";
                var options = new SessionCreateOptions
                {
                    SuccessUrl = domain + $"Shop/Thankyou",
                    CancelUrl = domain + "Shop/Cart",
                    LineItems = new List<SessionLineItemOptions>(),
                    Mode = "payment",
                    CustomerEmail = user.Email

                };
                foreach (var item in shoppingCartService.ShoppingCart)
                {
                    var sessionLineItem = new SessionLineItemOptions
                    {
                        PriceData = new SessionLineItemPriceDataOptions
                        {
                            UnitAmount = (long)((int)(item.Price * 100) * item.Quantity),
                            Currency = "usd",
                            ProductData = new SessionLineItemPriceDataProductDataOptions
                            {
                                Name = item.Name
                            }
                        },
                        Quantity = item.Quantity
                    };
                    options.LineItems.Add(sessionLineItem);
                }
                var service = new SessionService();
                Session session = service.Create(options);
                shoppingCartService.CheckoutSession = session.Id;

                shoppingCartService.CheckoutModel = model;
                shoppingCartService.Bought = shoppingCartService.ShoppingCart;
                shoppingCartService.Email = user.Email;
                shoppingCartService.CustomerId = user.Id;

                Response.Headers.Add("Location", session.Url);
                return new StatusCodeResult(303);
            }
            return View("Cart", shoppingCartService.ShoppingCart);
        }

        public async Task<IActionResult> ThankYou()
        {
            shoppingCartService.ShoppingCart = new List<LaptopModelDTO>();
            var service = new SessionService();
            Session session = service.Get(shoppingCartService.CheckoutSession);
            if (session.PaymentStatus=="paid")
            {
                return View("ThankYou",shoppingCartService.Bought);
            }
            return View("PaymentFail");
        }
        [AllowAnonymous]
        [HttpPost("/webhook")]
        public async Task<ActionResult> WebhookHandler()
        {
            System.Diagnostics.Debug.WriteLine("### I Am In WebhookHandler()");
            const string WEBHOOK_SECRET = "whsec_bf0af38039a01b66cd8f2babf3a7b79fddd571830ac16bcccb9a855bbb8a1ef6";
            var payload = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();

            try
            {
                var stripeEvent = EventUtility.ConstructEvent(
                  payload,
                  Request.Headers["Stripe-Signature"],
                  WEBHOOK_SECRET
                );
                if(stripeEvent.Type == Events.PaymentIntentCreated)
                {
                    var paymentIntent = stripeEvent.Data.Object as PaymentIntent;
                    System.Diagnostics.Debug.WriteLine("### PAYMENT INTENT:"+paymentIntent.Id);
                    shoppingCartService.checkout(paymentIntent.Id);
                }

                return Ok();
            }
            catch (StripeException e)
            {
                return BadRequest();
            }

          
        }
    }
}
