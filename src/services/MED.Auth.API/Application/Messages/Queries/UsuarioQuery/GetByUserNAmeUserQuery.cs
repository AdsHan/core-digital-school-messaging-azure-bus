using MED.Auth.Domain.Entities;
using MediatR;
using System;

namespace MED.Auth.API.Application.Messages.Queries.UserQuery
{
    public class GetByUserNAmeUserQuery : IRequest<UserModel>
    {
        public GetByUserNAmeUserQuery(string userName)
        {
            UserName = userName;
        }

        public String UserName { get; private set; }
    }
}
