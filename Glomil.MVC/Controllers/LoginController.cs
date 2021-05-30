using Glomil.BLL.Abstract;
using Glomil.BLL.Services;
using Glomil.MVC.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Glomil.MVC.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private IUsersBLL bLL;

        public LoginController(IUsersBLL bLL)
        {
            this.bLL = bLL;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel vm)
        {
            var user = bLL.UserLogin(vm.NickName, vm.Password);
            if (user != null)
            {
                IdHolder.IDHolder = user.Id;
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,vm.NickName)
                };
                var userIdentity = new ClaimsIdentity(claims, "GlomilCookie");
                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);

                await HttpContext.SignInAsync(principal);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(vm);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("index", "Home");
        }
    }
}
