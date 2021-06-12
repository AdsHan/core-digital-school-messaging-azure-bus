using MED.Auth.Domain.Entities;
using MediatR;
using System;

namespace MED.Auth.API.Application.Messages.Queries.UserQuery
{
    public class GetByIdUserQuery : IRequest<UserModel>
    {
        public GetByIdUserQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}
