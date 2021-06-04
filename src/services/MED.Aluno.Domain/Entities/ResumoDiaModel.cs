using MED.Core.DomainObjects;
using System;

namespace MED.Aluno.Domain.Entities
{
    public class ResumoDiaModel : BaseEntity, IAggregateRoot
    {

        // EF Construtor
        public ResumoDiaModel()
        {
        }

        public ResumoDiaModel(DateTime data, string texto, Guid alunoId)
        {
            DataResumo = data;
            Texto = texto;
            AlunoId = alunoId;
        }

        public DateTime DataResumo { get; private set; }
        public string Texto { get; private set; }

        public Guid? AlunoId { get; private set; }

        // EF Relação
        public AlunoModel Aluno { get; private set; }

    }
}
