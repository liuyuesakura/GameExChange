using System;
using System.Collections.Generic;
using System.Text;
using GameExChange.Repository.Contract;
using GameExChange.Repository.EntityFramework;
using GameExChange.Entity;
using Microsoft.EntityFrameworkCore;

namespace GameExChange.Repository.EntityRepository
{
    public class GameRepository : Repository<Game>,IGameRepository
    {

        public GameRepository(GameExChangeDbContext context) : base(context)
        {

        }
    }
}
