
using MED.Aluno.API.Application.DTO;
using MediatR;
using System.Collections.Generic;

namespace MED.Aluno.API.Application.Messages.Queries.AlunoQuery
{

    public class ObterTodosAlunoQuery : IRequest<List<AlunoDTO>>
    {
    }

}
