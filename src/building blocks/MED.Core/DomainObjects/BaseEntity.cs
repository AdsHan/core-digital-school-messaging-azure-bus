using MED.Core.Enums;
using System;

namespace MED.Core.DomainObjects
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime DataInclusao { get; private set; }
        public EntityStatusEnum Status { get; set; }

        protected BaseEntity()
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