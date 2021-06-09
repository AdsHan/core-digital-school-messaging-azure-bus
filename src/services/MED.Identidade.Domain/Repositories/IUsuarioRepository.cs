using MED.Core.Data;
using MED.Identidade.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace MED.Identidade.Domain.Repositories
{
    public interface IUsuarioRepository : IRepository<UsuarioModel>
    {
        Task<UsuarioModel> ObterPorUserNameAsync(string userName);
        Task<IdentityResult> CriarAsync(UsuarioModel usiario, string userName);
        Task<SignInResult> LogarAsync(string usuario, string senha);
        Task<SignInResult> VerificaSenhaAsync(UsuarioModel usuario, string senha);
    }
}
