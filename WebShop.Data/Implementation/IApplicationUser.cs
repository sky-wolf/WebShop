using WebShop.Data.Models;

namespace WebShop.Data.Implementation
{
    public interface IApplicationUser
    {
        ApplicationUser GetById(string id);
        List<ApplicationUser> GetAll();

        Task Add(ApplicationUser user);
        Task Deactivate(ApplicationUser user);
        Task SetProfileImage(string id, Uri uri);
    }
}
