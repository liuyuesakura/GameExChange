using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace GameExChange.Domain
{
    public interface ISpecification<T>
    {
        bool IsSatisfiedBy(T candidate);
        Expression<Func<T, bool>> Expression { get; }
    }
}
