using System.Linq.Expressions;

namespace GameExChange.Infrastructure.Specifications
{
    /// <summary>
    /// 将表达式中的参数替换为指定对象
    /// </summary>
    public class ParameterReplaceHelper : ExpressionVisitor
    {

        public ParameterReplaceHelper(ParameterExpression parameterExpression)
        {
            this.ParameterExpression = parameterExpression;
        }
        public ParameterExpression ParameterExpression { get; private set; }
        public Expression Replace(Expression expression)
        {
            return this.Visit(expression);
        }

        protected override Expression VisitParameter(ParameterExpression parameterExpression)
        {
            return this.ParameterExpression;
        }

    }
}
