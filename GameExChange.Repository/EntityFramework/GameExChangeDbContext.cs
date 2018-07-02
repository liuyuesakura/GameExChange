using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

using GameExChange.Domain.Model;

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
        public DbSet<User> Users
        {
            get { return Set<User>(); }
        }

        public DbSet<Game> Games
        {
            get { return Set<Game>(); }
        }

        public DbSet<Address> Addresses
        {
            get { return Set<Address>(); }
        }
        public DbSet<ExchangeRecord> ExchangeRecords
        {
            get { return Set<ExchangeRecord>(); }
        }

        #endregion

        #region protected method

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            //modelBuilder
            //    .Configurations
            //    .Add(new UserTypeConfiguration())
            //    .Add(new ProductTypeConfiguration())
            //    .Add(new CategoryTypeConfiguration())
            //    .Add(new ProductCategorizationTypeConfiguration())
            //    .Add(new OrderItemTypeConfiguration())
            //    .Add(new OrderTypeConfiguration())
            //    .Add(new ShoppingCartItemTypeConfiguration())
            //    .Add(new ShoppingCartTypeConfiguration())
            //    .Add(new RoleTypeConfiguration())
            //    .Add(new UserRoleTypeConfiguration());
            base.OnModelCreating(modelBuilder);

        }

        #endregion
    }
}
