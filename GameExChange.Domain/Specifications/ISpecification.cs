using System;
using System.Linq.Expressions;

namespace GameExChange.Domain.Specifications
{
    /// <summary>
    /// 规约接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ISpecification<T>
    {
        /// <summary>
        /// 判断是否满足规约
        /// </summary>
        /// <param name="candidate"></param>
        /// <returns></returns>
        bool IsSatisfiedBy(T candidate);
        /// <summary>
        /// 支持表达式树
        /// </summary>
        Expression<Func<T, bool>> Expression { get; }
    }
}
