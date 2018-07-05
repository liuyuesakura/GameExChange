using GameExChange.Domain.Repos;

namespace GameExChange.Repository.EntityFramework
{
    public interface IEntityFrameworkRepositoryContext :IRepositoryContext
    {
        GameExChangeDbContext DbContext { get; }
    }
}
