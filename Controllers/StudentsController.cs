using InstituteOfFineArts.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace InstituteOfFineArts.Controllers
{
    public class StudentsController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public StudentsController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> List()
        {
            var studentUsers = await UserHelpers.GetUsersInRoleAsync("Student", _userManager, _roleManager);
            return View(studentUsers);
        }
        public async Task<IActionResult> Details(string id)
        {
            var student = await _userManager.FindByIdAsync(id);
            return View(student);
        }
    }
}