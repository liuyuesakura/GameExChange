using System;
using System.Collections.Generic;
using System.Text;
using GameExChange.Entity;
using System.Linq;


namespace GameExChange.Repository.EntityFramework
{
    public static class DbInitializer
    {
        public static void Initailize(GameExChangeDbContext context)
        {
            context.Database.EnsureCreated();
            if (context.Set<User>().Any())
            {
                return;
            }
        }
    }
}
