
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MED.Core.MessageBus
{
    public class MessageBusHandler : IMessageBusHandler
    {
        private readonly string _connectionString;
        public MessageBusHandler(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("AzureServiceBusCs");
        }

        public async Task EnviarMenssagem(string queue, Event integration)
        {

            // Cria mensagem e envia para fila 
            var contentJson = JsonSerializer.Serialize<object>(integration);
            var contentBytes = Encoding.UTF8.GetBytes(contentJson);

            var queueClient = new QueueClient(_connectionString, queue);

            var message = new Message(contentBytes);

            await queueClient.SendAsync(message);
        }
    }
}
