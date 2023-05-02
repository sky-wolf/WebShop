using WebShop.Data;
using WebShop.Data.Implementation;
using WebShop.Data.Models;

namespace WebShop.Service
{
    public class ApplicationUserService : IApplicationUser
    {
        private readonly ApplicationDbContext _context;

        public ApplicationUserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Add(ApplicationUser user)
        {
            _context.Add(user);
            await _context.SaveChangesAsync();
        }

        public Task Deactivate(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public List<ApplicationUser> GetAll()
        {
            throw new NotImplementedException();
        }

        public ApplicationUser GetById(string id)
        {
            throw new NotImplementedException();
        }

        public Task SetProfileImage(string id, Uri uri)
        {
            throw new NotImplementedException();
        }
    }
}
