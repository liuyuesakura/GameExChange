using System;
using System.Collections.Generic;
using System.Text;
using GameExChange.Repository.Contract;
using GameExChange.Repository.EntityFramework;
using GameExChange.Entity;
using Microsoft.EntityFrameworkCore;

namespace GameExChange.Repository.EntityRepository
{
    public class ExChangeRecordRepository : Repository<ExchangeRecord>,IExchangeRecordRepository
    {
        public ExChangeRecordRepository(GameExChangeDbContext context) : base(context)
        {

        }
    }
}
