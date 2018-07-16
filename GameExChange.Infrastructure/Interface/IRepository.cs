using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using GameExChange.Infrastructure.Specifications;
using GameExChange.Infrastructure.Utils;

namespace GameExChange.Infrastructure.Interface
{
    public interface IRepository
    {
    }

    public interface IRepository<TEntity> :IRepository
        where TEntity :class
    {
        #region Normal Method

        void Add(TEntity entity);

        void AddAll(IEnumerable<TEntity> entities);

        void Update(TEntity entity);

        void Update(IEnumerable<TEntity> entities);

        void Delete(TEntity entity);

        void Delete(Expression<Func<TEntity, bool>> where);

        void Delete(object id);

        TEntity GetByID(object id);

        TEntity Get(Expression<Func<TEntity, bool>> where);

        IEnumerable<TEntity> GetList();

        IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> where);


        #endregion

        #region Specifications Method

        TEntity GetBySpecification(ISpecification<TEntity> spec);

        IEnumerable<TEntity> GetAllBySpecification(ISpecification<TEntity> spec);

        IEnumerable<TEntity> GetAllBySpecification(ISpecification<TEntity> spec, Expression<Func<TEntity, dynamic>> sortPredicate, SortOrder sortOrder);

        bool Exist(ISpecification<TEntity> spec);

        #endregion

        #region 分页
        PagedResult<TEntity> GetAll(Expression<Func<TEntity, dynamic>> sortPredicate,
            SortOrder sortOrder, int pageIndex, int pageSize);

        PagedResult<TEntity> GetAll(
            ISpecification<TEntity> specification,
            Expression<Func<TEntity, dynamic>> sortPredicate,
            SortOrder sortOrder, int pageIndex, int pageSize);

        PagedResult<TEntity> GetAll(Expression<Func<TEntity, dynamic>> sortPredicate,
            SortOrder sortOrder, int pageIndex, int pageSize,
            params Expression<Func<TEntity, dynamic>>[] eagerLoadingProperties);

        PagedResult<TEntity> GetAll(ISpecification<TEntity> specification,
            Expression<Func<TEntity, dynamic>> sortPredicate,
            SortOrder sortOrder, int pageIndex, int pageSize,
            params Expression<Func<TEntity, dynamic>>[] eagerLoadingProperties);

        #endregion
    }
}
