using DomainModel = GameExChange.Domain.Model;
using DomainRepo = GameExChange.Domain.Repos;

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