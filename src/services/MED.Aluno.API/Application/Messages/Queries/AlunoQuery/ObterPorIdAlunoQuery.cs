using MED.Aluno.Domain.Entities;
using MediatR;
using System;

namespace MED.Aluno.API.Application.Messages.Queries.AlunoQuery
{
    public class ObterPorIdAlunoQuery : IRequest<AlunoModel>
    {
        public ObterPorIdAlunoQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}
