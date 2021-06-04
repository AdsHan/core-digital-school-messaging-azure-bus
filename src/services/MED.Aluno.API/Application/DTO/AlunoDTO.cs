using MED.Core.DomainObjects;
using System;

namespace MED.Aluno.API.Application.DTO
{
    public class AlunoDTO
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public Rg Rg { get; private set; }
        public Cpf Cpf { get; private set; }

    }
}