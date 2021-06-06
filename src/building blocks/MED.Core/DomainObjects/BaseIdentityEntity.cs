using MED.Core.Enums;
using Microsoft.AspNetCore.Identity;
using System;

namespace MED.Core.DomainObjects
{
    public abstract class BaseIdentityEntity : IdentityUser
    {
        public Guid Id { get; set; }
        public DateTime DataInclusao { get; private set; }
        public EntityStatusEnum Status { get; set; }

        protected BaseIdentityEntity()
        {
            DataInclusao = DateTime.Now;
            Status = EntityStatusEnum.Ativa;
        }

        public void Excluir()
        {
            if (Status == EntityStatusEnum.Ativa)
            {
                Status = EntityStatusEnum.Inativa;
            }
        }
    }
}