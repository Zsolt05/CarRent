using Microsoft.AspNetCore.Mvc;

namespace CarRent.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
