using MED.Identidade.Domain.Entities;
using MediatR;
using System;

namespace MED.Identidade.API.Application.Messages.Queries.UsuarioQuery
{
    public class ObterPorIdUsuarioQuery : IRequest<UsuarioModel>
    {
        public ObterPorIdUsuarioQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}
