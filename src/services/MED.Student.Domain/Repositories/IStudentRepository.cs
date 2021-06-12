using MED.Core.Data;
using MED.Student.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace MED.Student.Domain.Repositories
{
    public interface IStudentRepository : IRepository<StudentModel>
    {
        Task<StudentModel> GetByCpfAsync(string cpf);
        Task<StudentModel> GetByRgAsync(string rg);
        Task<AdressModel> GetAdressByIdAsync(Guid id);
        Task<GuardianModel> GetGuardianByIdAsync(Guid id);
    }
}
