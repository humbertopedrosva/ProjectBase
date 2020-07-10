using System;

namespace ProjectBase.Domain.Base
{
    public abstract class EntityBase
    {
        public Guid Id { get; set; }
        protected EntityBase()
        {
            Id = Guid.NewGuid();
        }
    }
}
