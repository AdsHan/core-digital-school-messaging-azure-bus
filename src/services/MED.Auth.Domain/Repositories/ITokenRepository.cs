using MED.Auth.Domain.Entities;
using MED.Core.Data;
using System.Threading.Tasks;

namespace MED.Auth.Domain.Repositories
{
    public interface ITokenRepository : IRepository<TokenModel>
    {
        string GenerateToken(string UserName);
        Task<string> RefreshToken(string token);
    }
}
