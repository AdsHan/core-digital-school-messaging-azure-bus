using MED.Identidade.Domain.Entities;
using MediatR;
using System;

namespace MED.Identidade.API.Application.Messages.Queries.UsuarioQuery
{
    public class ObterPorUserNameUsuarioQuery : IRequest<UsuarioModel>
    {
        public ObterPorUserNameUsuarioQuery(string userName)
        {
            UserName = userName;
        }

        public String UserName { get; private set; }
    }
}
