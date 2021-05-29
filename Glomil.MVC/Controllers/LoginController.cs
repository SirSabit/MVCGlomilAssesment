using Glomil.BLL.Abstract;
using Glomil.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Glomil.MVC.Controllers
{
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
        public IActionResult Index(LoginViewModel vm)
        {
            var user=bLL.getUser(vm.NickName, vm.Password);
            if(user != null)
            {

            return RedirectToAction("index", "home");
            }
            else
            {
                return View();
            }
        }
    }
}
