using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RentaCar.Core.Dtos;
using System.Text;
using System.Text.Json;

var factory = new ConnectionFactory();
factory.Uri = new Uri("amqps://ozevqjhb:5a4K2bCcrHgVrgiyFtY6v1j8kVrFJd2I@moose.rmq.cloudamqp.com/ozevqjhb");

using var connection = factory.CreateConnection();

var channel = connection.CreateModel();

channel.QueueDeclare("customer", exclusive: false);

var consumer = new EventingBasicConsumer(channel);
consumer.Received += (model, eventArgs) => {
    var body = eventArgs.Body.ToArray();
  var message = Encoding.UTF8.GetString(body);
    var customerDto = JsonSerializer.Deserialize<CustomerDto>(message);
    Thread.Sleep(5000);
    Console.WriteLine("Kayıt Başarılı " +customerDto.Email);
};  
//read the message
channel.BasicConsume(queue: "customer", autoAck: true, consumer: consumer);
Console.ReadKey();