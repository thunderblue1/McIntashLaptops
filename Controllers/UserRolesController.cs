using McIntashLaptops.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace McIntashLaptops.Controllers
{
    [Authorize(Roles ="Manager")]
    public class UserRolesController : Controller
    {
        private RoleManager<IdentityRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager;

        public UserRolesController(RoleManager<IdentityRole> _roleManager, UserManager<ApplicationUser> _userManager)
        {
            roleManager = _roleManager;
            userManager = _userManager;
        }

        public IActionResult Index()
        {

            return View("Index",roleManager.Roles);
        }
        public IActionResult Create()
        {
            return View();
        }
        public async Task<IActionResult> SubmitRole(IdentityRole role) { 
            if(!await roleManager.RoleExistsAsync(role.Name))
            {
                await roleManager.CreateAsync(new IdentityRole(role.Name));
            }
            return View("Index",roleManager.Roles);
        }

        public async Task<IActionResult> Delete(string id) {
            var role = roleManager.Roles.Where(r=>r.Id==id).FirstOrDefault()!;
            await roleManager.DeleteAsync(role);
            return View("Index", roleManager.Roles);
        }

        public IActionResult ShowUsers()
        {
            return View("ShowUsers",userManager.Users);
        }

        public async Task<IActionResult> ManageRoles(string email)
        {
            var user = await userManager.FindByEmailAsync(email);

            return View(user);
        }
        public async Task<IActionResult> AddRoleToUser(string name, string email)
        {
            ApplicationUser user = await userManager.FindByEmailAsync(email);
            await userManager.AddToRoleAsync(user, name);
            return View("ManageRoles", user);
        }

        public async Task<IActionResult> DeleteRoleFromUser(string name, string email)
        {
            ApplicationUser user = await userManager.FindByEmailAsync(email);
            await userManager.RemoveFromRoleAsync(user, name);
            return View("ManageRoles", user);
        }
    }
}
