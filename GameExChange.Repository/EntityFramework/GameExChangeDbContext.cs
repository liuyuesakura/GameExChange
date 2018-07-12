using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using GameExChange.Entity;

namespace GameExChange.Repository.EntityFramework
{
    public class GameExChangeDbContext :DbContext
    {
        public GameExChangeDbContext(DbContextOptions<GameExChangeDbContext> options)
            :base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>().ToTable("User");
            builder.Entity<ExchangeRecord>().ToTable("ExChangeRecord");
            builder.Entity<Game>().ToTable("Game");
            builder.Entity<Address>().ToTable("Address");
        }
    }
}
