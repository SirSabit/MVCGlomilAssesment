using Glomil.MVC.RabbitMQ.Abstract;
using RabbitMQ.Client;
using System;
using System.Text;

namespace Glomil.MVC.RabbitMQ
{
    public class RabbitPublisher : IRabbitPublisher
    {
        public void CreatePublisher(string queueName, string message)
        {
            var factory = new ConnectionFactory();
            factory.Uri = new Uri("amqps://tvmcimss:P7uipg_a2o1-aW2QIZf_BbAaGfPLTM3D@beaver.rmq.cloudamqp.com/tvmcimss");

            using var connnection = factory.CreateConnection();

            var channel = connnection.CreateModel();

            channel.QueueDeclare(queueName, true, false, false);

            var mesageBody = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish(string.Empty, queueName, null, mesageBody);

        }
    }
}
