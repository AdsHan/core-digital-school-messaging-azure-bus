using MED.Student.Domain.Entities;
using MediatR;
using System;

namespace MED.Student.API.Application.Messages.Queries.StudentQuery
{
    public class GetByIdStudentQuery : IRequest<StudentModel>
    {
        public GetByIdStudentQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}
