using MED.Auth.API.Application.Messages.Commands.UserCommand;
using MED.Core.Mediator;
using MED.Core.Messages.Integration;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MED.Auth.API.Application.Messages.ConsumersBus
{
    public class CreateUserGuardianConsumer : ICreateUserGuardianConsumer
    {
        private readonly QueueClient _queueClient;
        private readonly IServiceProvider _serviceProvider;

        public CreateUserGuardianConsumer(IConfiguration configuration, IServiceProvider serviceProvider)
        {

            var connectionString = configuration.GetConnectionString("AzureServiceBusCs");

            _serviceProvider = serviceProvider;
            _queueClient = new QueueClient(connectionString, "new-user");

        }

        public void RegisterConsumer()
        {

            // Indico que o AutoComplete é falso para completar manualmente a fila (CompleteAsync)
            var messageHandlerOptions = new MessageHandlerOptions(ExceptionHandler)
            {
                AutoComplete = false
            };

            _queueClient.RegisterMessageHandler(ProcessMessage, messageHandlerOptions);
        }

        public async Task ProcessMessage(Message message, CancellationToken cancellationToken)
        {
            var messageString = Encoding.UTF8.GetString(message.Body);
            var user = JsonConvert.DeserializeObject<CreateUserGuardianEvent>(messageString);

            // Eu crio um scopo pois esta classe foi injetada com AddSingleton
            using (var scope = _serviceProvider.CreateScope())
            {

                var command = new AddUserCommand
                {
                    Email = user.Email,
                    Password = user.Password,
                    Phone = user.Phone
                };

                var mediator = scope.ServiceProvider.GetRequiredService<IMediatorHandler>();

                await mediator.SendCommand(command);

                await _queueClient.CompleteAsync(message.SystemProperties.LockToken);
            }
        }

        public Task ExceptionHandler(ExceptionReceivedEventArgs args)
        {
            return Task.CompletedTask;
        }

    }
}
