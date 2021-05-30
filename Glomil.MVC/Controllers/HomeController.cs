using Glomil.BLL.Abstract;
using Glomil.BLL.Concrete;
using Glomil.BLL.Services;
using Glomil.Entities.Entities;
using Glomil.MVC.Models;
using Glomil.MVC.RabbitMQ;
using Glomil.MVC.RabbitMQ.Abstract;
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
        private IQuestionAnswerBLL answerbLL;
        private IUsersBLL usersBLL;
        private IRabbitPublisher rabbitPublisher;
        

        public HomeController(IQuestionAnswerBLL answerbLL, IUsersBLL usersBLL,IRabbitPublisher rabbitPublisher)
        {
            this.answerbLL = answerbLL;
            this.usersBLL = usersBLL;
            this.rabbitPublisher = rabbitPublisher;
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

            QuestionAnswer question = new QuestionAnswer();
            question.Answer = vm.Answer;
            question.Question = (vm.FirstNumber + vm.CalculationType + vm.SecondNumber).ToString();
            question.UserId =IdHolder.IDHolder;
            rabbitPublisher.CreatePublisher("Queue",question.ToString());
           
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


            return RedirectToAction("index","Profile");
        }


    }
}
