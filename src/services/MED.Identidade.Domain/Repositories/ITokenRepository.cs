using MED.Core.Data;
using MED.Identidade.Domain.Entities;
using System.Threading.Tasks;

namespace MED.Identidade.Domain.Repositories
{
    public interface ITokenRepository : IRepository<TokenModel>
    {
        string GerarToken(string UserName);
        Task<string> AtualizarToken(string token);
    }
}
