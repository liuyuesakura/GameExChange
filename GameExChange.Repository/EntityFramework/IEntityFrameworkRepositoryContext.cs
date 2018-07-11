using GameExChange.Repository.Contract;
using GameExChange.Infrastructure.Interface;

namespace GameExChange.Repository.EntityFramework
{
    public interface IEntityFrameworkRepositoryContext :IRepositoryContext
    {
        GameExChangeDbContext DbContext { get; }
    }
}
