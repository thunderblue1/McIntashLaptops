using McIntashLaptops.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileSystemGlobbing.Internal.Patterns;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace McIntashLaptops.Controllers
{
    [Authorize(Roles ="Manager")]
    public class UserRolesController : Controller
    {
        private RoleManager<IdentityRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager;

        //The constructor is using injection to ensure that I have the UserManager and RoleManager available for the controller
        public UserRolesController(RoleManager<IdentityRole> _roleManager, UserManager<ApplicationUser> _userManager)
        {
            roleManager = _roleManager;
            userManager = _userManager;
        }

        //This returns a view showing all of the roles and provides a link to delete each of them
        public IActionResult Index()
        {

            return View("Index",roleManager.Roles);
        }

        //This returns the create view with a form to create a role
        public IActionResult Create()
        {
            return View();
        }

        //This is used to process the create form and save a role using RoleManager
        public async Task<IActionResult> SubmitRole(IdentityRole role) { 
            if(!await roleManager.RoleExistsAsync(role.Name))
            {
                await roleManager.CreateAsync(new IdentityRole(role.Name));
            }
            return View("Index",roleManager.Roles);
        }

        //This is used to delete a role with a particular id using the RoleManager
        public async Task<IActionResult> Delete(string id) {
            Func<IdentityRole, bool> predicate = (role) => role.Id==id;
            var role = roleManager.Roles.Where(predicate).FirstOrDefault()!;
            await roleManager.DeleteAsync(role);
            return View("Index", roleManager.Roles);
        }

        //This is used to return a view that shows all users and allows for users to be searched
        public IActionResult ShowUsers()
        {
            return View("ShowUsers",userManager.Users);
        }

        //This returns a view containing the details of a users account and the roles that they have
        //It has a section with roles that can be added to the user
        public async Task<IActionResult> ManageRoles(string email)
        {
            var user = await userManager.FindByEmailAsync(email);

            return View(user);
        }

        //This will add a role to the user and return to the role management section for a specific individual
        //This uses the UserManager
        public async Task<IActionResult> AddRoleToUser(string name, string email)
        {
            ApplicationUser user = await userManager.FindByEmailAsync(email);
            await userManager.AddToRoleAsync(user, name);
            return View("ManageRoles", user);
        }

        //This will remove a role for a user using the UserManager
        public async Task<IActionResult> DeleteRoleFromUser(string name, string email)
        {
            ApplicationUser user = await userManager.FindByEmailAsync(email);
            await userManager.RemoveFromRoleAsync(user, name);
            return View("ManageRoles", user);
        }

        //This is used to search for a user using LINQ
        public IActionResult Search(string searchTerm)
        {
            List<ApplicationUser> found = new List<ApplicationUser>();

            var pattern = Regex.Escape(searchTerm);
            pattern = ".*" + pattern + ".*";
            Func<ApplicationUser, bool> pred = user => Regex.IsMatch(user.Id, pattern)|| Regex.IsMatch(user.FirstName, pattern)
            || Regex.IsMatch(user.LastName, pattern)|| Regex.IsMatch(user.Email, pattern)|| Regex.IsMatch(user.PhoneNumber, pattern)
            || Regex.IsMatch(user.City, pattern)|| Regex.IsMatch(user.State, pattern)|| Regex.IsMatch(user.Zip, pattern)
            || Regex.IsMatch(user.Street, pattern)|| Regex.IsMatch(user.Country, pattern);

            //var test = Regex.IsMatch("f8216e1b-0ed6-4eab-ac99-6479c3c0b9b2", pattern);
            //System.Diagnostics.Debug.WriteLine("### TEST ### "+test);

            found = userManager.Users.Where(pred).ToList();
            return View("ShowUsers", found);
        }
    }
}
