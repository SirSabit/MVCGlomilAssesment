using Glomil.BLL.Abstract;
using Glomil.BLL.Concrete;
using Glomil.BLL.Services;
using Glomil.Entities.Entities;
using Glomil.MVC.Models;
using Glomil.MVC.RabbitMQ.Abstract;
using Glomil.MVC.RabbitMQ.HelperClass;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Glomil.MVC.Controllers
{

    public class HomeController : Controller
    {
        private IQuestionAnswerBLL answerbLL;
        private IUsersBLL usersBLL;
        
        private ICalculationBLL calculationBLL;


        public HomeController(IQuestionAnswerBLL answerbLL, IUsersBLL usersBLL,ICalculationBLL calculationBLL)
        {
            this.answerbLL = answerbLL;
            this.usersBLL = usersBLL;
            this.calculationBLL = calculationBLL;
            
        }
        public IActionResult Index()
        {
            HomeViewModel vm = new HomeViewModel();

            vm.QuestionList = answerbLL.GetAllQuestions();
            foreach (var item in vm.QuestionList)
            {
                var user = usersBLL.GetUserbyID(item.UserId);
            }

            return View(vm);
        }

        [HttpPost]
        public IActionResult Index(HomeViewModel vm)
        {

            if (vm.CalculationType == "+")
            {
                vm.Answer = calculationBLL.Addition(vm.FirstNumber, vm.SecondNumber);
            }
            else if (vm.CalculationType == "-")
            {
                vm.Answer = calculationBLL.Subtraction(vm.FirstNumber, vm.SecondNumber);
            }
            else if (vm.CalculationType == "/")
            {
                vm.Answer = calculationBLL.Division(vm.FirstNumber, vm.SecondNumber);
            }
            else if (vm.CalculationType == "*")
            {
                vm.Answer = calculationBLL.Multiplication(vm.FirstNumber, vm.SecondNumber);
            }
            QuestionAnswer question = new QuestionAnswer();
            question.Answer = vm.Answer;
            question.Question = (vm.FirstNumber + vm.CalculationType + vm.SecondNumber).ToString();
            question.UserId = IdHolder.IDHolder;

            answerbLL.AddQuestion(question);



            vm.QuestionList = answerbLL.GetAllQuestions();
            foreach (var item in vm.QuestionList)
            {
                var user = usersBLL.GetUserbyID(item.UserId);
            }

            return View(vm);

        }
        [HttpPost]
        public IActionResult Profile(HomeViewModel vm)
        {


            return RedirectToAction("index", "Profile");
        }


    }
}
