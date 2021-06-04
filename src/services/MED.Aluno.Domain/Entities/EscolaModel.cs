using MED.Core.DomainObjects;
using System;
using System.Collections.Generic;

namespace MED.Aluno.Domain.Entities
{
    public class EscolaModel : BaseEntity, IAggregateRoot
    {
        // EF Construtor
        public EscolaModel()
        {
        }

        public EscolaModel(string razaoSocial, string nomeFantasia, string cnpj, string email, string telefone, string celular, string observacao)
        {
            RazaoSocial = razaoSocial;
            NomeFantasia = nomeFantasia;
            Cnpj = new Cnpj(cnpj);
            Email = new Email(email);
            Telefone = new Telefone(telefone);
            Celular = new Telefone(celular);
            Observacao = new ObservacaoModel(observacao);
            Endereco = new EnderecoModel();
            Turmas = new List<TurmaModel>();
        }

        public string RazaoSocial { get; private set; }
        public string NomeFantasia { get; private set; }
        public Cnpj Cnpj { get; private set; }
        public Email Email { get; private set; }
        public Telefone Telefone { get; private set; }
        public Telefone Celular { get; private set; }
        public List<TurmaModel> Turmas { get; private set; }

        public Guid? ObservacaoId { get; private set; }
        public Guid? EnderecoId { get; private set; }

        // EF Relação
        public ObservacaoModel Observacao { get; private set; }
        public EnderecoModel Endereco { get; private set; }

        public void AtribuirEndereco(EnderecoModel endereco)
        {
            Endereco = endereco;
        }

        public void AtribuirTurmas(List<TurmaModel> turmas)
        {
            Turmas = turmas;
        }
    }
}
