
using MED.Student.API.Application.DTO;
using MediatR;
using System.Collections.Generic;

namespace MED.Student.API.Application.Messages.Queries.StudentQuery
{

    public class GetAllStudentQuery : IRequest<List<StudentDTO>>
    {
    }

}
