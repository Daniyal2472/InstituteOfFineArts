using InstituteOfFineArts.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace InstituteOfFineArts.Controllers
{
    public class StaffsController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public StaffsController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> List()
        {
            var staffUsers = await UserHelpers.GetUsersInRoleAsync("Staff", _userManager, _roleManager);
            return View(staffUsers);
        }
        public async Task<IActionResult> Details(string id)
        {
            var student = await _userManager.FindByIdAsync(id);
            return View(student);
        }
    }
}
