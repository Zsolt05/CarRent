using CarRent;
using CarRent.Data;
using CarRent.Models.Entities;

namespace CarRent.Services.Init
{
    public class CarInit
    {
        private readonly ApplicationDbContext _context;

        public CarInit(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Init()
        {
            if (!_context.Category.Any())
            {
                await _context.Category.AddAsync(new Category { categoryName = "kisautó" });
                await _context.Category.AddAsync(new Category { categoryName = "középkategóriás" });
                await _context.Category.AddAsync(new Category { categoryName = "sport kocsi" });
                await _context.Category.AddAsync(new Category { categoryName = "luxus" });
                await _context.Category.AddAsync(new Category { categoryName = "terepjáró" });
                await _context.SaveChangesAsync();
            }
            if (!_context.Cars.Any())
            {
                await _context.Cars.AddAsync(new Car { CategoryID = 1, brand = "Ford", model = "Fiesta", daily_price =30000 });
                await _context.Cars.AddAsync(new Car { CategoryID = 2, brand = "Audi", model = "A4", daily_price = 38000 });
                await _context.Cars.AddAsync(new Car { CategoryID = 3, brand = "Porsche", model = "911", daily_price = 40000 });
                await _context.Cars.AddAsync(new Car { CategoryID = 4, brand = "Toyota", model = "Crown", daily_price = 60000 });
                await _context.Cars.AddAsync(new Car { CategoryID = 5, brand = "Chevrolet ", model = "Suburban", daily_price = 38000 });
                await _context.SaveChangesAsync();
            }
        }
    }
}
