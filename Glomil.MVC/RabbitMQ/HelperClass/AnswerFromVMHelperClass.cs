using Glomil.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Glomil.MVC.RabbitMQ
{
    public class AnswerFromVMHelperClass
    {
        public static string UserId { get; set; }
        public static string Question { get; set; }
        public static string  Answer { get; set; }
    }
}
