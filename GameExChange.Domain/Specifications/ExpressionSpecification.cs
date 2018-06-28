using System;
using System.Linq.Expressions;

namespace GameExChange.Domain.Specifications
{
    /// <summary>
    /// 表达式树规约实现
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class ExpressionSpecification<T> : Specification<T>
    {
        private readonly Expression<Func<T, bool>> _expression;

        public ExpressionSpecification(Expression<Func<T, bool>> expression)
        {
            this._expression = expression;
        }

        public override Expression<Func<T, bool>> Expression
        {
            get { return _expression; }
        }
    }
}
