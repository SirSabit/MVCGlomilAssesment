using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Glomil.MVC.RabbitMQ
{
    public class AnswerCreatedEvent
    {
        public string Answer { get; set; }

        public string Question { get; set; }

        public string UserID { get; set; }
    }
}
