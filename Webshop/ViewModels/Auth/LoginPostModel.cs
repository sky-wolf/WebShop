using System.ComponentModel.DataAnnotations;

namespace WebShop.ViewModels.Auth
{
    public class LoginPostModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
