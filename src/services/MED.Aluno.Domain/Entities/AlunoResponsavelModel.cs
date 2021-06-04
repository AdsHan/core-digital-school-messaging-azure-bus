using System;

namespace MED.Aluno.Domain.Entities
{
    public class AlunoResponsavelModel
    {
        public AlunoResponsavelModel()
        {
        }

        public AlunoResponsavelModel(AlunoModel aluno, ResponsavelModel responsavel)
        {
            Aluno = aluno;
            Responsavel = responsavel;
        }

        public Guid AlunoId { get; private set; }
        public Guid ResponsavelId { get; private set; }

        // EF Relação        
        public AlunoModel Aluno { get; private set; }
        public ResponsavelModel Responsavel { get; private set; }
    }
}
