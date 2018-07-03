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
    public class GameRepository : EntityFramework.EntityFrameworkRepository<DomainModel.Game>, DomainRepo.IGameRepository
    {

        public GameRepository(DomainRepo.IRepositoryContext context)
            : base(context)
        {
        }

    }
}
