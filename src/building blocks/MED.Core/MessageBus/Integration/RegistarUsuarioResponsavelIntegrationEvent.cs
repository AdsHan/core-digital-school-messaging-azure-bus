using MED.Core.MessageBus;

namespace MED.Core.Messages.Integration
{
    public class RegistarUsuarioResponsavelIntegrationEvent : Event
    {
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Telefone { get; set; }

        public RegistarUsuarioResponsavelIntegrationEvent(string email, string senha, string telefone)
        {
            Email = email;
            Senha = senha;
            Telefone = telefone;
        }
    }
}