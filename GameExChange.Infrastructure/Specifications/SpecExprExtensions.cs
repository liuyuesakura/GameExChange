using System;
using System.Linq.Expressions;

namespace GameExChange.Infrastructure.Specifications
{
    /// <summary>
    /// 表达式树规约扩展方法
    /// </summary>
    public static class SpecExprExtensions
    {

        public static Expression<Func<T, bool>> Not<T>(this Expression<Func<T, bool>> expression)
        {
            var candidateExpression = expression.Parameters[0];
            var body = Expression.Not(expression.Body);
            return Expression.Lambda<Func<T, bool>>(body, candidateExpression);
        }

        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> one,
            Expression<Func<T, bool>> another)
        {
            var candidateExpression = Expression.Parameter(typeof(T), "candidate");
            var parameterReplaceHelper = new ParameterReplaceHelper(candidateExpression);

            var left = parameterReplaceHelper.Replace(one.Body);
            var right = parameterReplaceHelper.Replace(another.Body);

            var body = Expression.And(left, right);

            return Expression.Lambda<Func<T, bool>>(body, candidateExpression);
        }

        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> one,
            Expression<Func<T, bool>> another)
        {
            var candidateExpression = Expression.Parameter(typeof(T), "candidate");
            var parameterReplaceHelper = new ParameterReplaceHelper(candidateExpression);

            var left = parameterReplaceHelper.Replace(one.Body);
            var right = parameterReplaceHelper.Replace(another.Body);

            var body = Expression.Or(left, right);

            return Expression.Lambda<Func<T, bool>>(body, candidateExpression);
        }


        
    }
}
