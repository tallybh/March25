using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace Rabbit_example.Services
{
    public class RabbitMessager : IMessanger
    {
        public async Task SendMessage<T>(T message)
        {

            var factory = new ConnectionFactory
            {
                HostName = "localhost"
            };
            var connection = await factory.CreateConnectionAsync();
            using
            var channel = await connection.CreateChannelAsync();
            await channel.QueueDeclareAsync("product", exclusive: false);
            var json = JsonConvert.SerializeObject(message);
            var body = Encoding.UTF8.GetBytes(json);
            await channel.BasicPublishAsync(exchange: "", routingKey: "product", body: body);
        }


    }
}
