using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using CarRent.ViewModels;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using CarRent.Models.Entities;
using Azure.Identity;

namespace CarRent.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;

        public AccountController(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            this.signInManager = signInManager;
            this.userManager= userManager;
        }

        public IActionResult Login(string? returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)   //Login(LoginVM model, string? returnUrl = null)
        {
            //ViewData["ReturnUrl"] = returnUrl;

            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.Username!, model.Password!, true, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "Invalid login attempt"); //(string.Empty, "Invalid login attempt")
                return View(model);
            }

            return View(model);
        }

        public IActionResult Register()  //(string? returnUrl = null)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM model)
        {
            if (ModelState.IsValid)
            {
                User user = new()
                {
                    name = model.Name,
                    username = model.Username,
                    //passwordHash = model.Password   //kell?
                };
            

                var result = await userManager.CreateAsync(user, model.Password!);

                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, false);

                    return RedirectToAction("Index", "Home");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }
            
    public async Task<IActionResult> Logout()
    {
        await signInManager.SignOutAsync();
        return RedirectToAction("Index","Home");
    }

    private IActionResult RedirectToLocal(string? returnUrl)
    {
        if (Url.IsLocalUrl(returnUrl))
        {
            return Redirect(returnUrl);
        }
        else
        {
            return RedirectToAction(nameof(HomeController.Index), nameof(HomeController));
        }
    }
    }
    
    

    

}
