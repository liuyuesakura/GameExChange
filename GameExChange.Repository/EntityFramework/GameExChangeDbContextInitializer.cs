using System;
using System.Collections.Generic;
using System.Text;
//using System.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace GameExChange.Repository.EntityFramework
{
    //public sealed class GameExChangeDbContextInitializer : DropCreateDatabaseIfModelChanges<GameExChangeDbContext>
    //{
    //    /// <summary>
    //    /// 请在使用OnlineStoreDbContextInitailizer作为数据库初始化器（Database Initializer）时，去除以下代码行
    //    /// 的注释，以便在数据库重建时，相应的SQL脚本会被执行。对于已有数据库的情况，请直接注释掉以下代码行。
    //    /// </summary>
    //    /// <param name="context"></param>
    //    protected override void Seed(GameExChangeDbContext context)
    //    {
    //        //context.Database.ExecuteSqlCommand("CREATE UNIQUE INDEX IDX_CUSTOMER_USERNAME ON Users(UserName)");
    //        //context.Database.ExecuteSqlCommand("CREATE UNIQUE INDEX IDX_CUSTOMER_EMAIL ON Users(Email)");
    //        //context.Database.ExecuteSqlCommand("CREATE UNIQUE INDEX IDX_LAPTOP_NAME ON Laptops(Name)");
    //        base.Seed(context);
    //    }

    //    public static void Initialization()
    //    {
    //        Database.SetInitializer<GameExChangeDbContext>(null);
    //    }
    //}
}
