namespace RentaCar.API.RabbitMQ
{
    public interface IRabbitMQ
    {
        public void SendUserMessage<T>(T message);
    }
}
