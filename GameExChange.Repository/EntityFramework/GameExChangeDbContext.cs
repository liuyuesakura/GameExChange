using System;
using System.Collections.Generic;
//using System.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System.Text;

using GameExChange.Domain.Model;

using Microsoft.Extensions.Configuration;

//using Microsoft.Extensions.Configuration.Json;
using System.IO;
//using Microsoft.Extensions.Configuration.Json;

using System.Data.Common;
using System.Data;

namespace GameExChange.Repository.EntityFramework
{
    public sealed class GameExChangeDbContext :DbContext
    {
        #region ctro
        public GameExChangeDbContext(DbContextOptions<GameExChangeDbContext> options)
            :base(options)
        {

        }
        //public GameExChangeDbContext()
        //    : base("GameExChangeDB") //
        //{
        //    this.Configuration.AutoDetectChangesEnabled = true;
        //    this.Configuration.LazyLoadingEnabled = true;
        //}

        //public GameExChangeDbContext(string connectionString)
        //    : base(connectionString) //
        //{
        //    this.Configuration.AutoDetectChangesEnabled = true;
        //    this.Configuration.LazyLoadingEnabled = true;
        //}

        //protected override void OnConfiguring(DbContextOptionsBuilder builder)
        //{
        //    var cbuilder = new ConfigurationBuilder()
        //        .SetBasePath(Directory.GetCurrentDirectory())
        //        .AddJsonFile("appsettings.json");

        //    Microsoft.Extensions.Configuration.IConfiguration configuration = cbuilder.Build();
        //    //builder.Options;
        //    //var builder = new DbContextOptionsBuilder<GameExChangeDbContext>();
        //    builder.UseSqlServer(
        //    configuration.GetSection("MySqlConnection").Get<MySqlConnection>()
        //    );
        //}
        #endregion

        #region public 

        //public DbSet<T> ts
        //{
        //    get { return this.Set<T>}
        //}
        public DbSet<User> User
        {
            get { return Set<User>(); }
        }

        public DbSet<Game> Game
        {
            get { return Set<Game>(); }
        }

        public DbSet<Address> Address
        {
            get { return Set<Address>(); }
        }
        public DbSet<ExchangeRecord> ExchangeRecords
        {
            get { return Set<ExchangeRecord>(); }
        }

        #endregion

        #region protected method

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{

        //    //modelBuilder
        //    //    .Configurations
        //    //    .Add(new UserTypeConfiguration())
        //    //    .Add(new ProductTypeConfiguration())
        //    //    .Add(new CategoryTypeConfiguration())
        //    //    .Add(new ProductCategorizationTypeConfiguration())
        //    //    .Add(new OrderItemTypeConfiguration())
        //    //    .Add(new OrderTypeConfiguration())
        //    //    .Add(new ShoppingCartItemTypeConfiguration())
        //    //    .Add(new ShoppingCartTypeConfiguration())
        //    //    .Add(new RoleTypeConfiguration())
        //    //    .Add(new UserRoleTypeConfiguration());
        //    base.OnModelCreating(modelBuilder);

        //}


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            base.OnModelCreating(modelBuilder);


        }


        #endregion
    }
}
