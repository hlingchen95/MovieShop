using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MovieShopMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();  
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                // save the database
                var user = await _accountService.CreateUser(model);
                return RedirectToAction("Login");
            }

            return View(model);

        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid) return View();
            var userLogedIn = await _accountService.ValidateUser(model.Email, model.Password);
            if (userLogedIn != null)
            {
                var claims = new List<Claim>
                {
                    new Claim( ClaimTypes.Email, userLogedIn.Email),
                    new Claim( ClaimTypes.NameIdentifier, userLogedIn.Id.ToString()),
                    new Claim( ClaimTypes.GivenName, userLogedIn.FirstName),
                    new Claim( ClaimTypes.Surname, userLogedIn.LastName),
                    new Claim( ClaimTypes.DateOfBirth, userLogedIn.DateOfBirth.ToShortDateString()),
                    new Claim( "FullName", userLogedIn.FirstName + " " + userLogedIn.LastName),
                    new Claim( "Language", "en"),

                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                return LocalRedirect("~/");
            }
            else
            {
                return View();
            }
        }
        
    }
}
