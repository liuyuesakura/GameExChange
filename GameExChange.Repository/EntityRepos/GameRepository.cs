using DomainModel = GameExChange.Domain.Model;
using DomainRepo = GameExChange.Domain.Repos;

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
