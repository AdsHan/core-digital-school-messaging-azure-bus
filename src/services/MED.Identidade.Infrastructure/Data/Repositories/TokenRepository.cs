using MED.Core.Enums;
using MED.Identidade.Domain.Entities;
using MED.Identidade.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MED.Identidade.Infrastructure.Data.Repositories
{
    public class TokenRepository : ITokenRepository
    {
        private readonly IdentidadeDbContext _dbContext;
        private readonly IConfiguration _configuration;

        public TokenRepository(IdentidadeDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }

        public async Task<TokenModel> ObterPorUserNameAsync(string userName)
        {
            return await _dbContext.Tokens
                .Where(a => a.Status == EntityStatusEnum.Ativa)
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.UserName == userName);
        }

        public async Task<List<TokenModel>> ObterTodosAsync()
        {
            return await _dbContext.Tokens
                .Where(a => a.Status == EntityStatusEnum.Ativa)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<TokenModel> ObterPorIdAsync(Guid id)
        {
            return await _dbContext.Tokens
                .Where(a => a.Status == EntityStatusEnum.Ativa)
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public void Alterar(TokenModel token)
        {
            // Reforço que as entidades foram alteradas
            _dbContext.Entry(token).State = EntityState.Modified;
            _dbContext.Update(token);
        }

        public void Adicionar(TokenModel token)
        {
            _dbContext.Add(token);
        }

        public async Task SalvarAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public string GerarToken(string UserName)
        {
            // Define as claims do usuário (não é obrigatório, mas melhora a segurança (cria mais chaves no Payload))
            var claims = new[]
            {
                 new Claim(JwtRegisteredClaimNames.UniqueName, UserName),
                 new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
             };

            // Gera uma chave
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:key"]));

            // Gera a assinatura digital do token
            var credenciais = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Tempo de expiracão do token
            var expiracao = _configuration["TokenConfiguration:ExpireHours"];
            var expiration = DateTime.UtcNow.AddHours(double.Parse(expiracao));

            // Gera o token
            JwtSecurityToken token = new JwtSecurityToken(
              issuer: _configuration["TokenConfiguration:Issuer"],
              audience: _configuration["TokenConfiguration:Audience"],
              claims: claims,
              expires: expiration,
              signingCredentials: credenciais);

            // Retorna o token e demais informações
            return new JwtSecurityTokenHandler().WriteToken(token);

        }

        public async Task<string> AtualizarToken(string token)
        {
            var result = await _dbContext.Tokens.AsNoTracking().FirstOrDefaultAsync(u => u.Token == token);

            return result != null && result.DataExpiracao.ToLocalTime() > DateTime.Now ? GerarToken(result.UserName) : null;
        }


    }
}
