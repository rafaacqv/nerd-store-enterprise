using Microsoft.AspNetCore.Mvc;
using NSE.WebApp.MVC.Models;
using NSE.WebApp.MVC.Services.Interfaces;

namespace NSE.WebApp.MVC.Controllers
{
    public class IdentityController : Controller
    {
        private readonly IAuthenticationService _authenticationService;

        public IdentityController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpGet]
        [Route("new-account")]
        public IActionResult Register()
        {
            return View();  
        }

        [HttpPost]
        [Route("new-account")]
        public async Task<IActionResult> Register(UserRegister userRegister)
        {
            if(!ModelState.IsValid) return View(userRegister);

            //API Registro
            //Realizar login no App

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Route("login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(UserLogin userLogin)
        {
            if (!ModelState.IsValid) return View(userLogin);

            var response = await _authenticationService.Login(userLogin);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Route("logout")]
        public async Task<IActionResult> Logout()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
