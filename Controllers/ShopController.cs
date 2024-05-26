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
        
        //This constructor uses dependency injection to ensure that I have the UserManager and LaptopDAO readily available
        public ShopController(ILaptopDataService dataService, UserManager<ApplicationUser> _userManager)
        {
            laptopDAO = dataService;
            userManager = _userManager;
        }

        //This returns the shopping page
        public IActionResult Index()
        {
            return View("Index",laptopDAO.All());
        }

        //This returns a view with the results of a search
        public IActionResult SearchResults(string searchTerm)
        {
            List<LaptopModel> laptopModels = laptopDAO.SearchLaptops(searchTerm);
            return View("Index",laptopModels);
        }

        //This returns the cart view with all of the products in the cart
        public IActionResult Cart()
        {
            shoppingCartService.calculateTotal();
            return View("Cart", shoppingCartService.ShoppingCart);
        }

        //This will add a product to the cart from the shopping or details page
        public JsonResult AddToCart(int id)
        {
            LaptopModelDTO oneItem =  shoppingCartService.Add(id);
            return Json(oneItem);
        }

        //This will add to the quantity of a product in the cart from the cart
        public IActionResult AddOneToCart(int id)
        {
            LaptopModelDTO oneItem = shoppingCartService.Add(id);
            return PartialView("_laptopRowDTO", oneItem);
        }

        //This will remove one from the quantity of item in the cart from the cart
        //or remove the item from the cart if only one of the item is in the cart
        public IActionResult RemoveFromCart(int id)
        {
            LaptopModelDTO oneItem = shoppingCartService.Remove(id);
            return PartialView("_laptopRowDTO",oneItem);
        }

        //This is used to return a view that display one laptop record
        public IActionResult ShowOneLaptop(int Id)
        {
            return View(laptopDAO.GetLaptopById(Id));
        }

        //This is used to set the total of the cart on the view
        public JsonResult getTotalJson()
        {

            var total = shoppingCartService.getTotal();
            return Json(total);
        }

        //This is used for the process of receiving shipping information
        //and integrating the Stripe checkout into the site
        public async Task<ActionResult> checkout(CheckoutModel model)
        {
            ApplicationUser user = await userManager.FindByNameAsync(User.Identity.Name);

            if(shoppingCartService.ShoppingCart.Count>0&&ModelState.IsValid)
            {
                var domain = "https://mcintash.azurewebsites.net/";
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
                            UnitAmount = (long)((int)(item.Price * 100)),
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

        //This is the payment confirmation that is shown once the checkout process is complete
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

        //This is used to catch events emitted from Stripe
        //I am using it to fulfill orders upon payment intent success
        [AllowAnonymous]
        [HttpPost("/webhook")]
        public async Task<ActionResult> WebhookHandler()
        {
            System.Diagnostics.Debug.WriteLine("### I Am In WebhookHandler()");
            const string WEBHOOK_SECRET = "whsec_llFNP0oIe4DY45dEyixnM0KwJTWZW0dS";
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
