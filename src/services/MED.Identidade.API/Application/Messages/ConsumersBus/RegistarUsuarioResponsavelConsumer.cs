using MED.Core.Mediator;
using MED.Core.MessageBus;
using MED.Core.Messages.Integration;
using MED.Identidade.API.Application.Messages.Commands.UsuarioCommand;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MED.Identidade.API.Application.Messages.ConsumersBus
{
    public class RegistarUsuarioResponsavelConsumer : IRegistarUsuarioResponsavelConsumer, IConsumer
    {
        private readonly QueueClient _queueClient;
        private readonly IServiceProvider _serviceProvider;

        public RegistarUsuarioResponsavelConsumer(IConfiguration configuration, IServiceProvider serviceProvider)
        {

            var connectionString = configuration.GetConnectionString("AzureServiceBusCs");

            _serviceProvider = serviceProvider;
            _queueClient = new QueueClient(connectionString, "novo-usuario");

        }

        public void RegistrarConsumer()
        {

            // Indico que o AutoComplete é falso para completar manualmente a fila (CompleteAsync)
            var messageHandlerOptions = new MessageHandlerOptions(ExceptionHandler)
            {
                AutoComplete = false
            };

            _queueClient.RegisterMessageHandler(ProcessarMensagem, messageHandlerOptions);
        }

        public async Task ProcessarMensagem(Message message, CancellationToken cancellationToken)
        {
            var messageString = Encoding.UTF8.GetString(message.Body);
            var responsavelRegistrado = JsonConvert.DeserializeObject<RegistarUsuarioResponsavelIntegrationEvent>(messageString);

            // Eu crio um scopo pois esta classe foi injetada com AddSingleton
            using (var scope = _serviceProvider.CreateScope())
            {

                var command = new AdicionarUsuarioCommand
                {
                    Email = responsavelRegistrado.Email,
                    Senha = responsavelRegistrado.Senha,
                    Telefone = responsavelRegistrado.Telefone
                };

                var mediator = scope.ServiceProvider.GetRequiredService<IMediatorHandler>();

                await mediator.EnviarComando(command);

                await _queueClient.CompleteAsync(message.SystemProperties.LockToken);
            }
        }

        public Task ExceptionHandler(ExceptionReceivedEventArgs args)
        {
            return Task.CompletedTask;
        }

    }
}
