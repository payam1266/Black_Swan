using Black_Swan.MVC.Contracts;
using Black_Swan.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace Black_Swan.MVC.Controllers
{
    public class UsersController : Controller
    {
        private readonly IAuthenticateService _authenticateService;

        public UsersController(IAuthenticateService authenticateService)
        {
            _authenticateService = authenticateService;
        }
        public async  Task  <ActionResult> Login()
        {
          
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM login, string returnUrl)
        {
           
            returnUrl ??= Url.Content("~/");
            var isLoggedIn = await _authenticateService.Authenticate(login.Email, login.Passsword);
            if (isLoggedIn)
            {
                return LocalRedirect(returnUrl);
            }

            ModelState.AddModelError("", "Login Failed. Please Try again.");
            return View(login);
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task< IActionResult> Register(RegisterVM register)
        {
            if (!ModelState.IsValid)
            {
               
                return View(register);
            }
            var isCreated = await _authenticateService.Register(register);
            if (isCreated)
            {
                return LocalRedirect("/");
            }
            ModelState.AddModelError("", "Registration Failsd.");
            return View(register);

        }



      
        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            await _authenticateService.Logout();
            return LocalRedirect("/Users/Login");
        }

    }
}
