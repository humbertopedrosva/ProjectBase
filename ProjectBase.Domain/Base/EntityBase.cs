using System;
using System.Collections.Generic;
using System.Text;

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
