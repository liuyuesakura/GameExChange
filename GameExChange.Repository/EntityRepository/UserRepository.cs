using GameExChange.Entity;
using GameExChange.Repository.Contract;

namespace GameExChange.Repository.EntityRepository
{
    /// <summary>
    /// 用户仓储实现
    /// </summary>
    public class UserRepository : EntityFramework.EntityFrameworkRepository<User>, IUserRepository, IRepositoryMark
    {

        public UserRepository(IRepositoryContext context)
            : base(context)
        {
        }


    }
}
