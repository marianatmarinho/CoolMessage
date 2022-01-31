using CoolMessage.Producer.Broker.Event;
using CoolMessage.Producer.Configurations;
using CoolMessage.Producer.Domain.Interfaces;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;
using System.Threading.Tasks;

namespace CoolMessage.Producer.Domain.Services
{
    public class MessageService : IMessageService
    {
        private readonly RabbitMqConfiguration _configuration;
        private ConnectionFactory _factory;

        public MessageService(IOptions<RabbitMqConfiguration> option)
        {
            _configuration = option.Value;

            _factory = new ConnectionFactory
            {
                HostName = _configuration.Host
            };
        }

        public async Task PostMessage(MessageEvent message)
        {
            using (var connection = _factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(
                        queue: _configuration.Queue,
                        durable: false,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null);

                    var strinffiedMessage = JsonConvert.SerializeObject(message);
                    var bytesMessage = Encoding.UTF8.GetBytes(strinffiedMessage);

                    channel.BasicPublish(
                        exchange: "",
                        routingKey: _configuration.Queue,
                        basicProperties: null,
                        body: bytesMessage);
                }
            }
        }
    }
}
