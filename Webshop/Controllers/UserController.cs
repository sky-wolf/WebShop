using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using WebShop.Data.Implementation;
using WebShop.Data.Models;
using WebShop.ViewModels.Auth;
using WebShop.ViewModels.User;

namespace WebShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        

        public UserController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] ViewModels.Auth.RegisterModel registerModel)
        {
            if (ModelState.IsValid)
            {
                var user_exist = await _userManager.FindByEmailAsync(registerModel.Email);
                if (user_exist == null)
                {
                    var user = new ApplicationUser
                    {
                        UserName = registerModel.UserName,
                        Email = registerModel.Email,
                        NormalizedUserName = registerModel.Email.ToUpper(),
                        NormalizedEmail = registerModel.Email.ToUpper(),

                    };

                    var result = await _userManager.CreateAsync(user, registerModel.Password);

                    if (result.Succeeded)
                    {
                        await _userManager.AddToRoleAsync(user, "User");

                        return Ok();
                    }
                }
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("Admins")]
        [Authorize(Roles = "Admin")]
        public IActionResult AdminEndPoint()
        {
            var currentUser = GetCurrentUser();
            return Ok($"Hi you are an {currentUser.Id}");
        }

        private UserModel GetCurrentUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            if(identity != null)
            {
                var userClaims = identity.Claims;
                return new UserModel
                {
                    Id = userClaims.FirstOrDefault(x => x.Type == "UserId")?.Value,
                    Username = userClaims.FirstOrDefault(x => x.Type == "Username")?.Value,
                    Role = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value,
                };
            }
            return null;
        }
        
    }
}
