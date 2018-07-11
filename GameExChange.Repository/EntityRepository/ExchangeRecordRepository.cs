using GameExChange.Entity;
using GameExChange.Repository.Contract;

namespace GameExChange.Repository.EntityRepository
{
    /// <summary>
    /// 游戏仓储实现
    /// </summary>
    public class ExchangeRepositoryRepository : EntityFramework.EntityFrameworkRepository<ExchangeRecord>, IExchangeRecordRepository, IRepositoryMark
    {

        public ExchangeRepositoryRepository(IRepositoryContext context)
            : base(context)
        {
        }


    }
}