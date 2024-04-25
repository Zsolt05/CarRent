using CarRent.Data;
using CarRent.Models.Entities;
using CarRent.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarRent.Controllers
{
    public class CarController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public CarController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> List(int categoryNumber)
        {
            if (categoryNumber != 0)
            {
                var cars = await dbContext.Cars.Where(c => c.CategoryID == categoryNumber).ToListAsync();
                return View(cars);
            }
            else 
            {
                var cars = await dbContext.Cars.ToListAsync();
                return View(cars);
            }
            
        }
        /*public IActionResult Index()
        {
            return View();
        }*/
    }
}
