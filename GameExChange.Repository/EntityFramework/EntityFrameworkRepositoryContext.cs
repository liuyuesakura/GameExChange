using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using System.Threading;
using GameExChange.Domain.Repos;

namespace GameExChange.Repository.EntityFramework
{
    public class EntityFrameworkRepositoryContext:IEntityFrameworkRepositoryContext
    {
        private readonly ThreadLocal<GameExChangeDbContext> _localCtx = new ThreadLocal<GameExChangeDbContext>(() => new GameExChangeDbContext());

        public GameExChangeDbContext DbContext
        {
            get { return _localCtx.Value; }
        }

        private readonly Guid _id = Guid.NewGuid();

        #region IRepositoryContext Members

        public Guid ID
        {
            get { return _id; }
        }

        void RegisterNew<TAggregateRoot>(TAggregateRoot entity) where TAggregateRoot :class,Domain.IAggregateRoot
        {
            _localCtx.Value.Set<TAggregateRoot>().Add(entity);
        }

        void RegisterModify<TAggregateRoot>(TAggregateRoot entity) where TAggregateRoot :class ,Domain.IAggregateRoot
        {
            _localCtx.Value.Entry<TAggregateRoot>(entity).State = EntityState.Modified;
        }

        void RegisterDelete<TAggregateRoot>(TAggregateRoot entity) where TAggregateRoot:class,Domain.IAggregateRoot
        {
            _localCtx.Value.Set<TAggregateRoot>().Remove(entity);
        }

        #endregion

        #region IUnitWork Members
        public void Commit()
        {
            var validationError = _localCtx.Value.GetValidationErrors();
            _localCtx.Value.SaveChanges();
        }


        #endregion
    }
}
