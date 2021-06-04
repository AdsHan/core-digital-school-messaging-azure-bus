using MED.Core.DomainObjects;
using System;
using System.Collections.Generic;

namespace MED.Aluno.Domain.Entities
{
    public class AlunoModel : BaseEntity, IAggregateRoot
    {
        // EF Construtor
        public AlunoModel()
        {
        }

        public AlunoModel(string nome, DateTime dataNascimento, string rg, string cpf, string observacao, Guid turmaId)
        {
            Nome = nome;
            DataNascimento = dataNascimento;
            TurmaId = turmaId;
            Rg = new Rg(rg);
            Cpf = new Cpf(cpf);
            Observacao = new ObservacaoModel(observacao);
            Endereco = new EnderecoModel();
            AlunosResponsaveis = new List<AlunoResponsavelModel>();
            Resumos = new List<ResumoDiaModel>();
        }

        public string Nome { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public Rg Rg { get; private set; }
        public Cpf Cpf { get; private set; }

        public Guid? TurmaId { get; private set; }
        public Guid? EnderecoId { get; private set; }
        public Guid? ObservacaoId { get; private set; }

        public List<AlunoResponsavelModel> AlunosResponsaveis { get; set; }
        public List<ResumoDiaModel> Resumos { get; private set; }

        // EF Relação
        public ObservacaoModel Observacao { get; private set; }
        public EnderecoModel Endereco { get; private set; }
        public TurmaModel Turma { get; private set; }

        public void AtribuirEndereco(EnderecoModel endereco)
        {
            Endereco = endereco;
        }

        public void AtribuirResponsaveis(List<AlunoResponsavelModel> responsaveis)
        {
            AlunosResponsaveis = responsaveis;
        }

        public void AtribuirResumos(List<ResumoDiaModel> resumos)
        {
            Resumos = resumos;
        }

        public void Atualizar(string nome, DateTime dataNascimento, string rg, string cpf, string observacao, Guid turma)
        {
            Nome = nome;
            DataNascimento = dataNascimento;
            Rg.Atualizar(rg);
            Cpf.Atualizar(cpf);
            Observacao.Atualizar(observacao);
            TurmaId = turma;
        }

    }
}
