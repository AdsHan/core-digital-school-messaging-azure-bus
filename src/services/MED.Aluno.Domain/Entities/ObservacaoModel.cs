using MED.Core.DomainObjects;

namespace MED.Aluno.Domain.Entities
{
    public class ObservacaoModel : BaseEntity
    {
        public string Texto { get; private set; }

        public ObservacaoModel(string texto)
        {
            Texto = texto;
        }
        public void Atualizar(string texto)
        {
            Texto = texto;
        }
    }

}
