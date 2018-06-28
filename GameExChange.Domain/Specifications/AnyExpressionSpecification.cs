using System;
using System.Linq.Expressions;

namespace GameExChange.Domain.Specifications
{
    /// <summary>
    /// 无条件表达式规约
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class AnyExpressionSpecification<T> : Specification<T>
    {
        public override Expression<Func<T, bool>> Expression
        {
            get { return o => true; }
        }

    }
}
