using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace GameExChange.Repository.EntityFramework
{
    public sealed class GameExChangeDbContext :DbContext
    {
        #region ctro
        public GameExChangeDbContext()
            : base("GameExChangeDB")
        {
            this.Configuration.AutoDetectChangesEnabled = true;
            this.Configuration.LazyLoadingEnabled = true;
        }
        #endregion

        #region public 

        //public DbSet<T> ts
        //{
        //    get { return this.Set<T>}
        //}

        #endregion

        #region protected method

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }

        #endregion
    }
}
