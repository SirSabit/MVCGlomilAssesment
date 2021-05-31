using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using System;

namespace Glomil.MVC.RabbitMQ
{
    public class RabbitMQClientService : IDisposable
    {
        private readonly ConnectionFactory connectionFactory;
        private IConnection connection;
        private IModel channel;
        public static string ExchangeName = "AnswerDirectExchange";
        public static string RoutingAnswer = "answer-route";
        public static string QueueName = "queue-answer";

        private readonly ILogger<RabbitMQClientService> logger;

        public RabbitMQClientService(ConnectionFactory connectionFactory, ILogger<RabbitMQClientService> logger)
        {
            this.logger = logger;
            this.connectionFactory = connectionFactory;

        }

        public IModel Connect()
        {
            connection = connectionFactory.CreateConnection();
            if (channel is { IsOpen: true })
            {
                return channel;
            }

            channel = connection.CreateModel();

            channel.ExchangeDeclare(ExchangeName, type: "direct", true, false);

            channel.QueueDeclare(QueueName, true, false, false, null);

            channel.QueueBind(exchange: ExchangeName, queue: QueueName, routingKey: RoutingAnswer);

            logger.LogInformation("Connected!");

            return channel;
        }

        public void Dispose()
        {
            channel?.Close();
            channel?.Dispose();

            connection.Close();
            connection.Dispose();

            logger.LogInformation("Connection Closed");
        }
    }
}
