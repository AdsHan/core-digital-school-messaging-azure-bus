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
        private readonly SignInManager<UsuarioModel> _signInManager;
        private readonly UserManager<UsuarioModel> _userManager;

        public UsuarioRepository(UserManager<UsuarioModel> userManager, SignInManager<UsuarioModel> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<UsuarioModel> ObterPorUserNameAsync(string userName)
        {
            return await _userManager.Users
                .Where(a => a.Status == EntityStatusEnum.Ativa)
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.UserName == userName);
        }

        public async Task<List<UsuarioModel>> ObterTodosAsync()
        {
            return await _userManager.Users
                .Where(a => a.Status == EntityStatusEnum.Ativa)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<UsuarioModel> ObterPorIdAsync(Guid id)
        {
            return await _userManager.Users
                .Where(a => a.Status == EntityStatusEnum.Ativa)
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IdentityResult> CriarAsync(UsuarioModel usuario, string senha)
        {
            return await _userManager.CreateAsync(usuario, senha);

        }

        public async Task<SignInResult> LogarAsync(string usuario, string senha)
        {
            return await _signInManager.PasswordSignInAsync(usuario, senha, isPersistent: false, lockoutOnFailure: true);
        }

        public async Task<SignInResult> VerificaSenhaAsync(UsuarioModel usuario, string senha)
        {
            return await _signInManager.CheckPasswordSignInAsync(usuario, senha, lockoutOnFailure: true);
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

        }
    }
}
