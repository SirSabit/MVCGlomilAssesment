using Glomil.BLL.Abstract;
using Glomil.Entities.Entities;
using Glomil.MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Glomil.MVC.Controllers
{
    [AllowAnonymous]
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
            if (ModelState.IsValid)
            {
                Users newUser = new Users();
                newUser.Name = vm.Name;
                newUser.Surname = vm.Surname;
                newUser.NickName = vm.NickName;
                newUser.Password = vm.Password;
                newUser.BirthDate = vm.BirthDate;
                newUser.IsActive = true;

                bLL.AddUser(newUser);



                return RedirectToAction("Index", "Login");
            }


            return View(vm);
        }
    }
}
