using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using WebShop.Data.Implementation;
using WebShop.Data.Models;
using WebShop.ViewModels.Auth;

namespace WebShop.Controllers
{
    [Route("token")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IAccessTokenRepository _accessTokenRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public AuthenticateController(IAccessTokenRepository accessTokenRepository, UserManager<ApplicationUser> userManager)
        {
            _accessTokenRepository = accessTokenRepository;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginPostModel loginModel)
        {
            var user = await _userManager.FindByNameAsync(loginModel.Username);
   
            if (user != null && await _userManager.CheckPasswordAsync(user, loginModel.Password))
            {
                var token = await _accessTokenRepository.GetToken(user);
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    username = user.UserName,
                });
            }
            return Unauthorized();
        }

        
    }
}
