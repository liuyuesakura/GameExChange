using System;
//using System.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System.Threading;
using GameExChange.Domain.Repos;


using Microsoft.Extensions.Configuration;
using System.IO;


namespace GameExChange.Repository.EntityFramework
{
    public class EntityFrameworkRepositoryContext:IEntityFrameworkRepositoryContext
    {
        private ThreadLocal<GameExChangeDbContext> _localCtx = null;
            //new ThreadLocal<GameExChangeDbContext>(() => new GameExChangeDbContext());

        public GameExChangeDbContext DbContext
        {
            get
            {
                if (_localCtx == null)
                {
                    var cbuilder = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json");
                    Microsoft.Extensions.Configuration.IConfiguration configuration = cbuilder.Build();
                    MySqlConnection connection = configuration.GetSection("MySqlConnection").Get<MySqlConnection>();

                    //new DbContextOptions<GameExChangeDbContext>()

                    var builder = new DbContextOptionsBuilder<GameExChangeDbContext>();
                    //builder.Options;
                    //var builder = new DbContextOptionsBuilder<GameExChangeDbContext>();
                    builder.UseSqlServer(connection.ConnectionString);



                    _localCtx = new ThreadLocal<GameExChangeDbContext>(
                        () => new GameExChangeDbContext(builder.Options)
                    );
                    //_localCtx = new ThreadLocal<GameExChangeDbContext>(
                    //    () => new GameExChangeDbContext()
                    //);

                }
                return _localCtx.Value;
            }
        }

        private readonly Guid _id = Guid.NewGuid();

        #region IRepositoryContext Members

        public Guid ID
        {
            get { return _id; }
        }

        public void RegisterNew<TAggregateRoot>(TAggregateRoot entity) where TAggregateRoot :class,Domain.IAggregateRoot
        {

            ///DbContext.Database.EnsureCreated();

            if (_localCtx == null)
                DbContext.Set<TAggregateRoot>().Add(entity);
            else
                _localCtx.Value.Set<TAggregateRoot>().Add(entity);
        }

        public void RegisterModify<TAggregateRoot>(TAggregateRoot entity) where TAggregateRoot :class ,Domain.IAggregateRoot
        {
            if (_localCtx == null)
                DbContext.Entry<TAggregateRoot>(entity).State = EntityState.Modified;
            else
                _localCtx.Value.Entry<TAggregateRoot>(entity).State = EntityState.Modified;
        }

        public void RegisterDelete<TAggregateRoot>(TAggregateRoot entity) where TAggregateRoot:class,Domain.IAggregateRoot
        {
            if (_localCtx == null)
                DbContext.Set<TAggregateRoot>().Remove(entity);
            else
                _localCtx.Value.Set<TAggregateRoot>().Remove(entity);
        }

        #endregion

        #region IUnitWork Members
        public void Commit()
        {
            //var validationError = _localCtx.Value.GetValidationErrors();
            if (_localCtx == null)
                DbContext.SaveChanges();
            else
                _localCtx.Value.SaveChanges();
        }


        #endregion
    }

    public class MssqlConnection
    {
        /// <summary>  
        /// 连接字符串  
        /// </summary>  
        public string ConnectionString { get; set; }
    }

    public class MySqlConnection
    {
        /// <summary>  
        /// 连接字符串  
        /// </summary>  
        public string ConnectionString { get; set; }
    }
}
