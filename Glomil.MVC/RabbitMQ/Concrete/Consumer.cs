using RabbitMQ.Client;
using System;

namespace Glomil.MVC.RabbitMQ
{
    public class Consumer
    {
        public void CreateConsumer(string queueName, string message)
        {
            var factory = new ConnectionFactory();
            factory.Uri = new Uri("amqps://tvmcimss:P7uipg_a2o1-aW2QIZf_BbAaGfPLTM3D@beaver.rmq.cloudamqp.com/tvmcimss");

            using var connnection = factory.CreateConnection();

            var channel = connnection.CreateModel();

            channel.QueueDeclare(queueName, true, false, false);



        }
    }
}
