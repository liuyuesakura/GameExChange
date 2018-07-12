using System;
using System.Collections.Generic;
using System.Text;
using GameExChange.Repository.Contract;
using GameExChange.Repository.EntityFramework;
using GameExChange.Entity;
using Microsoft.EntityFrameworkCore;

namespace GameExChange.Repository.EntityRepository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(GameExChangeDbContext context) : base(context)
        {
        }


    }
}
