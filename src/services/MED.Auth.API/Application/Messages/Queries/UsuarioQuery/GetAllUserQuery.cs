
using MED.Auth.API.Application.DTO;
using MediatR;
using System.Collections.Generic;

namespace MED.Auth.API.Application.Messages.Queries.UserQuery
{

    public class GetAllUserQuery : IRequest<List<UserDTO>>
    {
    }

}
