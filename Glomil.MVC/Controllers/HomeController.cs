using Glomil.BLL.Abstract;
using Glomil.BLL.Concrete;
using Glomil.MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Glomil.MVC.Controllers
{
    
    public class HomeController : Controller
    {
      
        
        public IActionResult Index()
        {
            HomeViewModel vm = new HomeViewModel();

            return View(vm);
        }

        [HttpPost]
        public IActionResult Index(HomeViewModel vm)
        {
            CalculationsBLL calculations = new CalculationsBLL();
            
            if (vm.CalculationType == "+")
            {
                vm.Answer = calculations.Addition(vm.FirstNumber, vm.SecondNumber);
            }
            else if (vm.CalculationType == "-")
            {
                vm.Answer = calculations.Subtraction(vm.FirstNumber, vm.SecondNumber);
            }
            else if (vm.CalculationType == "/")
            {
                vm.Answer = calculations.Division(vm.FirstNumber, vm.SecondNumber);
            }
            else if (vm.CalculationType == "*")
            {
                vm.Answer = calculations.Multiplication(vm.FirstNumber, vm.SecondNumber);
            }

            return View(vm);

        }


    }
}
