using GameExChange.Domain.Model;
using Microsoft.EntityFrameworkCore;




namespace GameExChange.Repository.EntityFramework
{
    public sealed class GameExChangeDbContext :DbContext
    {
        #region ctro
        public GameExChangeDbContext(DbContextOptions<GameExChangeDbContext> options)
            :base(options)
        {

        }
        #endregion

        #region public 

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


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            base.OnModelCreating(modelBuilder);


        }


        #endregion
    }
}
