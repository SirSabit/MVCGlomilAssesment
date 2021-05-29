using Glomil.BLL.Abstract;
using Glomil.Entities.Entities;
using Glomil.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Glomil.MVC.Controllers
{
    public class RegisterController : Controller
    {
        private IUsersBLL bLL;

        public RegisterController(IUsersBLL bLL)
        {
            this.bLL = bLL;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(RegisterViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                var messages = ModelState.ToList();
                


                return View(vm);
            }
            Users newUser = new Users();
            newUser.Name = vm.Name;
            newUser.Surname = vm.Surname;
            newUser.NickName = vm.NickName;
            newUser.Password = vm.Password;
            newUser.BirthDate = vm.BirthDate;
            newUser.IsActive = true;
            
            bLL.AddUser(newUser);

            return View();
        }
    }
}
