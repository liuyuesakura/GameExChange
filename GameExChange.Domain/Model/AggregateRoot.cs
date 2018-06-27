using System;
using System.Collections.Generic;
using System.Text;

namespace GameExChange.Domain.Model
{
    public abstract class AggregateRoot:IAggregateRoot
    {
        public Guid Id
        {
            get;
            set;
        }
    }
}
