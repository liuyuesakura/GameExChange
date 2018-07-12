using GameExChange.Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

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
            if(DBContext.Entry(entity).State == EntityState.Detached)
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

        public IEnumerable<TEntity> GetList()
        {
            return DbSet.ToList();
        }

        public IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> where)
        {
            return DbSet.Where<TEntity>(where).ToList();
        }

        public void Update(TEntity entity)
        {
            DbSet.Attach(entity);
            DBContext.Entry(entity).State = EntityState.Modified;
        }

        public void Update(IEnumerable<TEntity> entities)
        {
            foreach(var obj in entities)
            {
                DbSet.Attach(obj);
                DBContext.Entry(obj).State = EntityState.Modified;
            }
        }
    }
}
