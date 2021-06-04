using MED.Core.DomainObjects;
using System;
using System.Collections.Generic;

namespace MED.Aluno.Domain.Entities
{
    public class TurmaModel : BaseEntity, IAggregateRoot
    {

        // EF Construtor
        public TurmaModel()
        {
        }

        public TurmaModel(string nome, string observacao, Guid escolaId)
        {
            EscolaId = escolaId;
            Nome = nome;
            Observacao = new ObservacaoModel(observacao);
            Alunos = new List<AlunoModel>();
        }

        public string Nome { get; private set; }
        public List<AlunoModel> Alunos { get; private set; }

        public Guid? EscolaId { get; private set; }
        public Guid? ObservacaoId { get; private set; }

        // EF Relação        
        public ObservacaoModel Observacao { get; private set; }
        public EscolaModel Escola { get; private set; }

        public void AtribuirAlunos(List<AlunoModel> alunos)
        {
            Alunos = alunos;
        }
    }
}
