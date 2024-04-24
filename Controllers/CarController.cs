using CarRent.Data;
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
        public async Task<IActionResult> List()
        {
            var cars= await dbContext.Cars.ToListAsync();

            return View(cars);
        }
        /*public IActionResult Index()
        {
            return View();
        }*/
    }
}
