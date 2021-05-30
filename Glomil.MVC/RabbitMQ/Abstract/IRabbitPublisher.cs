namespace Glomil.MVC.RabbitMQ.Abstract
{
    public interface IRabbitPublisher
    {
        public void CreatePublisher(string queueName, string message);
    }
}
