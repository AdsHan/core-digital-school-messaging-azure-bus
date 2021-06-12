using MED.Core.DomainObjects;

namespace MED.Student.Domain.Entities
{
    public class NoteModel : BaseEntity
    {
        public string Text { get; private set; }

        public NoteModel(string text)
        {
            Text = text;
        }
        public void Update(string text)
        {
            Text = text;
        }
    }

}
