using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace RentaCar.API.RabbitMQ
{
    public class MessageBrokerRabbit : IRabbitMQ
    {
        public void SendUserMessage<T>(T message)
        {
            var factory = new ConnectionFactory();
            factory.Uri = new Uri("amqps://ozevqjhb:5a4K2bCcrHgVrgiyFtY6v1j8kVrFJd2I@moose.rmq.cloudamqp.com/ozevqjhb");
            using var connection = factory.CreateConnection();

            var channel = connection.CreateModel();

            channel.QueueDeclare(queue: "customer", durable: true, exclusive: false, autoDelete: false);

            var json = JsonConvert.SerializeObject(message);
            var body = Encoding.UTF8.GetBytes(json);
            //put the data on to the product queue
            channel.BasicPublish(exchange: "", routingKey: "customer", body: body);
        }
    }
}
