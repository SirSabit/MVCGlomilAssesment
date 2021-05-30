using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Glomil.MVC.RabbitMQ.Abstract
{
  public interface IRabbitPublisher
    {
        public void CreatePublisher(string queueName, string message);
    }
}
