using Glomil.Entities.Entities;
using System.Collections.Generic;

namespace Glomil.MVC.Models
{
    public class HomeViewModel
    {
        public double FirstNumber { get; set; }

        public string CalculationType { get; set; }

        public double SecondNumber { get; set; }
        public string Answer { get; set; }

        public List<QuestionAnswer> QuestionList { get; set; }


    }
}
