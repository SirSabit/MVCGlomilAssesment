using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace Glomil.MVC.RabbitMQ
{
    public class RabbitMQPublisher
    {
        private readonly RabbitMQClientService rabbitMQClientService;

        public RabbitMQPublisher(RabbitMQClientService rabbitMQClientService)
        {
            this.rabbitMQClientService = rabbitMQClientService;
        }

        public void Publish(AnswerCreatedEvent answerCreatedEvent)
        {
            var channel = rabbitMQClientService.Connect();

            var bodyString = JsonSerializer.Serialize(answerCreatedEvent);

            var bodyByte = Encoding.UTF8.GetBytes(bodyString);

            var properties = channel.CreateBasicProperties();

            properties.Persistent = true;

            channel.BasicPublish(exchange: RabbitMQClientService.ExchangeName, routingKey: RabbitMQClientService.RoutingAnswer, basicProperties: properties, body: bodyByte);
        }
    }
}
