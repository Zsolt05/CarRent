using CarRent.Data;
using CarRent.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarRent.Controllers
{
    public class CustomUserStore
    {
        private readonly ApplicationDbContext _context;

        public CustomUserStore(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> FindByNameAsync(string userName)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.UserName == userName);
        }

        public async Task<bool> CheckPasswordAsync(User user, string password)
        {
            return user.Password == password; 
        }

    }
}
