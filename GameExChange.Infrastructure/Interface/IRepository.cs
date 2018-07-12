using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

namespace GameExChange.Infrastructure.Interface
{
    public interface IRepository
    {
    }

    public interface IRepository<TEntity> :IRepository
        where TEntity :class
    {
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


    }
}
