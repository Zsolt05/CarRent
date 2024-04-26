using CarRent;
using CarRent.Data;
using CarRent.Models.Entities;

namespace CarRent.Services.Init
{
    public class UserInit
    {
        private readonly ApplicationDbContext _context;

        public UserInit(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Init()
        {
            if (!_context.Users.Any())
            {
                await _context.Users.AddAsync(new User { username = "KisP", name="Kiss Pista", password="123" });
                await _context.Users.AddAsync(new User { username = "NagyG", name = "Nagy Gergely", password = "456" });
                await _context.Users.AddAsync(new User { username = "KözK", name = "Közepes Krisztián", password = "789" });
                await _context.SaveChangesAsync();
            }
        }
    }
}