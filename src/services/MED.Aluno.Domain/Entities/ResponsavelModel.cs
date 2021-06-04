using MED.Core.DomainObjects;
using System;
using System.Collections.Generic;

namespace MED.Aluno.Domain.Entities
{
    public class ResponsavelModel : BaseEntity, IAggregateRoot
    {
        // EF Construtor
        public ResponsavelModel()
        {
        }

        public ResponsavelModel(string nome, DateTime dataNascimento, string rg, string cpf, string telefone, string celular, string email, string observacao)
        {
            Nome = nome;
            DataNascimento = dataNascimento;
            Rg = new Rg(rg);
            Cpf = new Cpf(cpf);
            Email = new Email(email);
            Telefone = new Telefone(telefone);
            Celular = new Telefone(celular);
            Observacao = new ObservacaoModel(observacao);
            AlunosResponsaveis = new List<AlunoResponsavelModel>();
        }

        public string Nome { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public Rg Rg { get; private set; }
        public Cpf Cpf { get; private set; }
        public Email Email { get; private set; }
        public Telefone Telefone { get; private set; }
        public Telefone Celular { get; private set; }

        public Guid? ObservacaoId { get; private set; }

        public List<AlunoResponsavelModel> AlunosResponsaveis { get; set; }

        // EF Relação
        public ObservacaoModel Observacao { get; private set; }

        public void AtribuirAlunos(List<AlunoResponsavelModel> alunos)
        {
            AlunosResponsaveis = alunos;
        }

        public void Atualizar(string nome, DateTime dataNascimento, string rg, string cpf, string telefone, string celular, string email, string observacao)
        {
            Nome = nome;
            DataNascimento = dataNascimento;
            Rg.Atualizar(rg);
            Cpf.Atualizar(cpf);
            Telefone.Atualizar(telefone);
            Celular.Atualizar(celular);
            Email.Atualizar(email);
            Observacao.Atualizar(observacao);
        }
    }
}
