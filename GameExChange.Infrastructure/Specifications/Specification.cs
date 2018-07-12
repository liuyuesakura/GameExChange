using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GameExChange.Infrastructure.Specifications
{
    /// <summary>
    /// 规约实现
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Specification<T> : ISpecification<T>
    {
        /// <summary>
        /// 表达式抽象定义
        /// </summary>
        public abstract Expression<Func<T, bool>> Expression { get; }

        /// <summary>
        /// 表达式树规约方法
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static Specification<T> Eval(Expression<Func<T,bool>> expression)
        {
            return new ExpressionSpecification<T>(expression);
        }
        /// <summary>
        /// 判断表达式树是否满足规约
        /// </summary>
        /// <param name="candidate"></param>
        /// <returns></returns>
        public  bool IsSatisfiedBy(T candidate)
        {
            return this.Expression.Compile()(candidate);
        }
    }
}
