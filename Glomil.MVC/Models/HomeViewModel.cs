﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Glomil.MVC.Models
{
    public class HomeViewModel
    {
        public double FirstNumber { get; set; }

        public string CalculationType { get; set; }

        public double SecondNumber { get; set; }
        public double Answer { get; set; } = 0;

        public int UserId { get; set; }
    }
}
