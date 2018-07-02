using System;
using System.Collections.Generic;
using System.Text;

using GameExChange.Domain;
using DomainRepo = GameExChange.Domain.Repos;
using DomainModel = GameExChange.Domain.Model;

namespace GameExChange.Repository.EntityRepos
{
    /// <summary>
    /// 游戏仓储实现
    /// </summary>
    public class ExchangeRepositoryRepository : EntityFramework.EntityFrameworkRepository<DomainModel.ExchangeRecord>, DomainRepo.IExchangeRecordRepository
    {

        public ExchangeRepositoryRepository(DomainRepo.IRepositoryContext context)
            : base(context)
        {
        }


    }
}