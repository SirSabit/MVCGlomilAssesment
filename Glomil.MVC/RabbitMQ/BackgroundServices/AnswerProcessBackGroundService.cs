using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Glomil.MVC.RabbitMQ.BackgroundServices
{
    public class AnswerProcessBackGroundService : BackgroundService
    {
        private readonly RabbitMQClientService rabbitMQClientService;
        private readonly ILogger<AnswerProcessBackGroundService> logger;
        private IModel channel;



        public AnswerProcessBackGroundService(RabbitMQClientService rabbitMQClientService, ILogger<AnswerProcessBackGroundService> logger)
        {
            this.logger = logger;
            this.rabbitMQClientService = rabbitMQClientService;

        }
        public override Task StartAsync(CancellationToken cancellationToken)
        {
            channel = rabbitMQClientService.Connect();

            channel.BasicQos(0, 1, false);

            return base.StartAsync(cancellationToken);
        }
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = new AsyncEventingBasicConsumer(channel);

            channel.BasicConsume(RabbitMQClientService.QueueName, false, consumer);

            consumer.Received += Consumer_Received;

            return Task.CompletedTask;
        }

        private Task Consumer_Received(object sender, BasicDeliverEventArgs @event)
        {
            var answerCreatedEvent = JsonSerializer.Deserialize<AnswerCreatedEvent>(Encoding.UTF8.GetString(@event.Body.ToArray()));


            AnswerFromVMHelperClass.Answer = answerCreatedEvent.Answer;
            AnswerFromVMHelperClass.Question = answerCreatedEvent.Question;
            AnswerFromVMHelperClass.UserId = answerCreatedEvent.UserID;

            channel.BasicAck(@event.DeliveryTag, false);

            return Task.CompletedTask;
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            return base.StopAsync(cancellationToken);
        }
    }
}
