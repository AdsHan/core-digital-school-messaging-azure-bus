using MED.Core.Enums;
using MED.Identidade.Domain.Entities;
using MED.Identidade.Domain.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MED.Identidade.Infrastructure.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public readonly IdentidadeDbContext _dbContext;
        public readonly UserManager<UsuarioModel> _userManager;

        public UsuarioRepository(IdentidadeDbContext dbContext, UserManager<UsuarioModel> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        public async Task<UsuarioModel> ObterPorUserNameAsync(string userName)
        {
            return await _dbContext.Usuarios
                .Where(a => a.Status == EntityStatusEnum.Ativa)
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.UserName == userName);
        }

        public async Task<List<UsuarioModel>> ObterTodosAsync()
        {
            return await _dbContext.Usuarios
                .Where(a => a.Status == EntityStatusEnum.Ativa)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<UsuarioModel> ObterPorIdAsync(Guid id)
        {
            return await _dbContext.Usuarios
                .Where(a => a.Status == EntityStatusEnum.Ativa)
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IdentityResult> CriarAsync(UsuarioModel usuario, string senha)
        {
            return await _userManager.CreateAsync(usuario, senha);

        }

        public Task SalvarAsync()
        {
            throw new NotImplementedException();
        }

        public void Alterar(UsuarioModel obj)
        {
            throw new NotImplementedException();
        }

        public void Adicionar(UsuarioModel obj)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
