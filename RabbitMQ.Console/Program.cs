using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RentaCar.Core.Dtos;
using System.Text;
using System.Text.Json;

var factory = new ConnectionFactory();
factory.Uri = new Uri("amqps://ozevqjhb:5a4K2bCcrHgVrgiyFtY6v1j8kVrFJd2I@moose.rmq.cloudamqp.com/ozevqjhb");

using var connection = factory.CreateConnection();

var channel = connection.CreateModel();

channel.QueueDeclare(queue: "customer", durable: true, exclusive: false, autoDelete: false);
var consumer = new EventingBasicConsumer(channel);
channel.BasicConsume(queue: "customer", autoAck: true, consumer: consumer);


consumer.Received += (object sender, BasicDeliverEventArgs e) => { 
    var body = e.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);
    var customerDtos = JsonSerializer.Deserialize<CustomerDto>(message);
    Thread.Sleep(5000);
    Console.WriteLine("Kayıt Başarılı" + customerDtos.Email);
    channel.BasicAck(e.DeliveryTag, false);
};
//read the message 
Console.ReadKey();
