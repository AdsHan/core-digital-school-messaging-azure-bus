using MED.Core.DomainObjects;
using System;

namespace MED.Identidade.Domain.Entities
{
    public class TokenModel : BaseEntity, IAggregateRoot
    {
        // EF Construtor
        public TokenModel()
        {

        }

        public TokenModel(string userName, string token, DateTime dataExpiracao)
        {
            UserName = userName;
            Token = token;
            DataExpiracao = dataExpiracao;
        }

        public string UserName { get; private set; }
        public string Token { get; private set; }
        public DateTime DataExpiracao { get; private set; }

    }
}
