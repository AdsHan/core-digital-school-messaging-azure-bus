
using MED.Identidade.API.Application.DTO;
using MediatR;
using System.Collections.Generic;

namespace MED.Identidade.API.Application.Messages.Queries.UsuarioQuery
{

    public class ObterTodosUsuariosQuery : IRequest<List<UsuarioDTO>>
    {
    }

}
