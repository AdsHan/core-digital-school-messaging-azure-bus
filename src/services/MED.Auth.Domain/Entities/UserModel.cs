using MED.Core.DomainObjects;

namespace MED.Auth.Domain.Entities
{
    public class UserModel : BaseIdentityEntity, IAggregateRoot
    {
        // EF Construtor
        public UserModel()
        {

        }
    }
}
