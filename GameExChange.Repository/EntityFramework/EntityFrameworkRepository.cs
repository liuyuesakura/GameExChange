using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

using GameExChange.Domain;
using GameExChange.Domain.Repos;
using GameExChange.Domain.Specifications;

namespace GameExChange.Repository.EntityFramework
{
    public abstract class EntityFrameworkRepository
    {
    }

    public abstract class EntityFrameworkRepository<TAggregateRoot> : IRepository<TAggregateRoot>
        where TAggregateRoot : class, IAggregateRoot
    {
        private readonly IEntityFrameworkRepositoryContext _efContext;

        protected EntityFrameworkRepository(IRepositoryContext context)
        {
            var efContext = context as IEntityFrameworkRepositoryContext;
            if (efContext != null)
                this._efContext = efContext;
        }

        private MemberExpression GetMemberInfo(LambdaExpression lambda)
        {
            if (lambda == null)
                throw new ArgumentNullException("lambda");

            MemberExpression memberExpr = null;

            switch (lambda.Body.NodeType)
            {
                case ExpressionType.Convert:
                    memberExpr =
                        ((UnaryExpression)lambda.Body).Operand as MemberExpression;
                    break;
                case ExpressionType.MemberAccess:
                    memberExpr = lambda.Body as MemberExpression;
                    break;
            }

            if (memberExpr == null)
                throw new ArgumentException("method");

            return memberExpr;
        }

        private string GetEagerLoadingPath(Expression<Func<TAggregateRoot, dynamic>> eagerLoadingProperty)
        {
            var memberExpression = this.GetMemberInfo(eagerLoadingProperty);
            var parameterName = eagerLoadingProperty.Parameters.First().Name;
            var memberExpressionStr = memberExpression.ToString();
            var path = memberExpressionStr.Replace(parameterName + ".", "");
            return path;
        }

        protected IEntityFrameworkRepositoryContext EfContext
        {
            get { return this._efContext; }
        }

        public void Add(TAggregateRoot aggregateRoot)
        {
            // 调用IEntityFrameworkRepositoryContext的RegisterNew方法将实体添加进DbContext.DbSet对象中
            _efContext.RegisterNew(aggregateRoot);
        }

        public TAggregateRoot GetByKey(int key)
        {
            return _efContext.DbContext.Set<TAggregateRoot>().First(a => a.ID == key);
        }

        public TAggregateRoot GetBySpecification(ISpecification<TAggregateRoot> spec)
        {
            return _efContext.DbContext.Set<TAggregateRoot>().FirstOrDefault(spec.Expression);
        }

        public TAggregateRoot GetByExpression(Expression<Func<TAggregateRoot, bool>> expression)
        {
            return _efContext.DbContext.Set<TAggregateRoot>().FirstOrDefault(expression);
        }

        public IEnumerable<TAggregateRoot> GetAll()
        {
            return GetAll(new AnyExpressionSpecification<TAggregateRoot>(), null, SortOrder.UnSpecified);
        }

        public IEnumerable<TAggregateRoot> GetAll(ISpecification<TAggregateRoot> specification)
        {
            return GetAll(specification, null, SortOrder.UnSpecified);
        }


        public IEnumerable<TAggregateRoot> GetAll(Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder)
        {
            return GetAll(new AnyExpressionSpecification<TAggregateRoot>(), sortPredicate, sortOrder);
        }

        public IEnumerable<TAggregateRoot> GetAll(ISpecification<TAggregateRoot> specification, Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder)
        {
            var query = _efContext.DbContext.Set<TAggregateRoot>().Where(specification.Expression);

            //动态排序的实现
            //if (sortPredicate != null)
            //{
            //    switch (sortOrder)
            //    {
            //        case SortOrder.Ascending:
            //            return query.SortBy(sortPredicate).ToList();
            //            break;
            //        case SortOrder.Descending:
            //            return query.SortByDescending(sortPredicate).ToList();
            //            break;
            //        default:
            //            break;
            //    }
            //}

            return query.ToList();
        }

        public bool Exists(ISpecification<TAggregateRoot> specification)
        {
            var count = _efContext.DbContext.Set<TAggregateRoot>().Count(specification.IsSatisfiedBy);
            return count != 0;
        }

        public void Remove(TAggregateRoot aggregateRoot)
        {
            _efContext.RegisterDelete(aggregateRoot);
        }

        public void Update(TAggregateRoot aggregateRoot)
        {
            _efContext.RegisterModify(aggregateRoot);
        }
    }
}
