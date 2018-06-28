using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;

namespace GameExChange.Repository.EntityFramework
{
    public sealed class GameExChangeDbContextInitializer :DropCreateDatabaseIfModelChanges<GameExChangeDbContext>
    {
        protected override void Seed(GameExChangeDbContext context)
        {
            //context.Database.ExecuteSqlCommand("CREATE UNIQUE INDEX IDX_CUSTOMER_USERNAME ON Users(UserName)");
            //context.Database.ExecuteSqlCommand("CREATE UNIQUE INDEX IDX_CUSTOMER_EMAIL ON Users(Email)");
            //context.Database.ExecuteSqlCommand("CREATE UNIQUE INDEX IDX_LAPTOP_NAME ON Laptops(Name)");
            base.Seed(context);
        }

        public static void Initialization()
        {
            Database.SetInitializer<GameExChangeDbContext>(null);
        }
    }
}
