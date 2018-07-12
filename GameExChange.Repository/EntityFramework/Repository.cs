using GameExChange.Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using GameExChange.Infrastructure.Specifications;
using GameExChange.Infrastructure.Utils;

namespace GameExChange.Repository.EntityFramework
{
    public abstract class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {

        protected DbContext DBContext;
        protected DbSet<TEntity> DbSet;


        public Repository(DbContext dbContext)
        {
            this.DBContext = dbContext;
            this.DbSet = dbContext.Set<TEntity>();
        }


        #region Normal Method 

        public virtual void Add(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public virtual void AddAll(IEnumerable<TEntity> entities)
        {
            DbSet.AddRange(entities);
        }

        public virtual void Delete(TEntity entity)
        {
            if (DBContext.Entry(entity).State == EntityState.Detached)
            {
                DbSet.Attach(entity);
            }
            DbSet.Remove(entity);
        }

        public virtual void Delete(Expression<Func<TEntity, bool>> where)
        {
            IEnumerable<TEntity> entities = DbSet.Where<TEntity>(where).AsEnumerable();
            DbSet.RemoveRange(entities);
        }

        public virtual void Delete(object id)
        {
            TEntity entity = DbSet.Find(id);
            Delete(entity);
        }

        public virtual TEntity Get(Expression<Func<TEntity, bool>> where)
        {
            return DbSet.Where<TEntity>(where).FirstOrDefault();

        }

        public virtual TEntity GetByID(object id)
        {
            return DbSet.Find(id);

        }

        public virtual IEnumerable<TEntity> GetList()
        {
            return DbSet.ToList();
        }

        public virtual IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> where)
        {
            return DbSet.Where<TEntity>(where).ToList();
        }

        public virtual void Update(TEntity entity)
        {
            DbSet.Attach(entity);
            DBContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Update(IEnumerable<TEntity> entities)
        {
            foreach (var obj in entities)
            {
                DbSet.Attach(obj);
                DBContext.Entry(obj).State = EntityState.Modified;
            }
        }


        #endregion

        #region Specification Method

        public bool Exist(ISpecification<TEntity> spec)
        {
            var count = DbSet.Count(spec.IsSatisfiedBy);
            return count != 0;
        }

        public TEntity GetBySpecification(ISpecification<TEntity> spec)
        {
            return DbSet.FirstOrDefault(spec.IsSatisfiedBy);
        }

        public IEnumerable<TEntity> GetAllBySpecification(ISpecification<TEntity> spec)
        {
            return GetAllBySpecification(spec, null, SortOrder.UnSpecified);
        }

        public virtual IEnumerable<TEntity> GetAllBySpecification(ISpecification<TEntity> spec, Expression<Func<TEntity, dynamic>> sortPredicate, SortOrder sortOrder)
        {
            var query = DbSet.Where(spec.Expression);

            if (sortPredicate != null)
            {
                switch (sortOrder)
                {
                    case SortOrder.Ascending:
                        return query.OrderBy(sortPredicate).ToList();

                    case SortOrder.Descending:
                        return query.OrderByDescending(sortPredicate).ToList();
                    default: break;
                }
            }
            return query.ToList();
        }

        #endregion
    }
}
