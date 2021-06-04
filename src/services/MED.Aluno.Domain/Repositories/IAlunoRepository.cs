using MED.Aluno.Domain.Entities;
using MED.Core.Data;
using System;
using System.Threading.Tasks;

namespace MED.Aluno.Domain
{
    public interface IAlunoRepository : IRepository<AlunoModel>
    {
        Task<AlunoModel> ObterPorCpfAsync(string cpf);
        Task<AlunoModel> ObterPorRgAsync(string rg);
        Task<EnderecoModel> ObterEnderecoPorIdAsync(Guid id);
        Task<ResponsavelModel> ObterResponsavelPorIdAsync(Guid id);
    }
}
