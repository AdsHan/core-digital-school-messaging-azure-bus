using System;

namespace MED.Core.Messages.Integration
{
    public class ResponsavelRegistradoIntegrationEvent : Event
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Cpf { get; private set; }
        public string Senha { get; private set; }
        public string SenhaConfirmacao { get; private set; }

        public ResponsavelRegistradoIntegrationEvent(Guid id, string nome, string email, string cpf, string senha, string senhaConfirmacao)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Cpf = cpf;
            Senha = senha;
            SenhaConfirmacao = senhaConfirmacao;
        }
    }
}