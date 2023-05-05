using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebShop.Data.Models;

namespace WebShop.Admin.Controllers
{
    public class UserController : Controller
    {
        readonly RoleManager<IdentityRole> _roleManager;
        readonly UserManager<ApplicationUser> _userManager;

        public UserController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View(_userManager.Users);
        }

        [HttpGet("id")]
        public async Task<IActionResult> Delete(string id)
        {
            var delete = await _userManager.FindByIdAsync(id);
            if (delete != null)
            {
                await _userManager.DeleteAsync(delete);
                return RedirectToAction("Index");
            }
            return BadRequest();
        }
    }
}
