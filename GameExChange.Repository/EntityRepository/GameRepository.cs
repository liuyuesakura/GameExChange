using GameExChange.Entity;
using GameExChange.Repository.Contract;

namespace GameExChange.Repository.EntityRepository
{
    /// <summary>
    /// 游戏仓储实现
    /// </summary>
    public class GameRepository : EntityFramework.EntityFrameworkRepository<Game>, IGameRepository, IRepositoryMark
    {

        public GameRepository(IRepositoryContext context)
            : base(context)
        {
        }

    }
}
