using Glomil.BLL.Abstract;
using Glomil.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace Glomil.MVC.Controllers
{
    public class ProfileController : Controller
    {
        private IUsersBLL usersBLL;
        public ProfileController(IUsersBLL usersBLL)
        {
            this.usersBLL = usersBLL;
        }
        [HttpGet]
        public IActionResult Index(int id)
        {
            var user = usersBLL.GetUserbyID(id);
            ProfileViewModel vm = new ProfileViewModel();
            vm.Name = user.Name;
            vm.Surname = user.Surname;
            vm.Nickname = user.NickName;
            vm.BirthDate = user.BirthDate;

            return View(vm);
        }
    }
}
