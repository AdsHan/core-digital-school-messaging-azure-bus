using MED.Aluno.Domain;
using MED.Aluno.Domain.Entities;
using MED.Core.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MED.Aluno.Infrastructure.Data.Repositories
{
    public class AlunoRepository : IAlunoRepository
    {
        public readonly AlunoDbContext _dbContext;
        public AlunoRepository(AlunoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<EnderecoModel> ObterEnderecoPorIdAsync(Guid id)
        {
            return await _dbContext.Enderecos
                .Where(a => a.Status == EntityStatusEnum.Ativa)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<ResponsavelModel> ObterResponsavelPorIdAsync(Guid id)
        {
            return await _dbContext.Responsaveis
                .Include(a => a.Observacao)
                .Where(a => a.Status == EntityStatusEnum.Ativa)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<AlunoModel> ObterPorCpfAsync(string cpf)
        {
            return await _dbContext.Alunos
                .Where(a => a.Status == EntityStatusEnum.Ativa)
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Cpf.Numero == cpf);
        }

        public async Task<AlunoModel> ObterPorIdAsync(Guid id)
        {
            return await _dbContext.Alunos
                .Where(a => a.Status == EntityStatusEnum.Ativa)
                .Include(x => x.AlunosResponsaveis).ThenInclude(i => i.Responsavel)
                .Include(a => a.Observacao)
                .Include(a => a.Endereco)
                .Include(a => a.Resumos)
                .Include(a => a.Turma)
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<AlunoModel> ObterPorRgAsync(string rg)
        {
            return await _dbContext.Alunos
                .Where(a => a.Status == EntityStatusEnum.Ativa)
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Rg.Numero == rg);
        }

        public async Task<List<AlunoModel>> ObterTodosAsync()
        {
            return await _dbContext.Alunos
                .Where(a => a.Status == EntityStatusEnum.Ativa)
                .AsNoTracking()
                .ToListAsync();
        }

        public void Alterar(AlunoModel aluno)
        {
            // Reforço que as entidades foram alteradas
            _dbContext.Entry(aluno).State = EntityState.Modified;
            _dbContext.Entry(aluno.Endereco).State = EntityState.Modified;
            _dbContext.Entry(aluno.Observacao).State = EntityState.Modified;
            _dbContext.Update(aluno);
        }

        public void Adicionar(AlunoModel aluno)
        {
            _dbContext.Add(aluno);
        }

        public async Task SalvarAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

    }
}
