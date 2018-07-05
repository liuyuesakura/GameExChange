using DomainModel = GameExChange.Domain.Model;
using DomainRepo = GameExChange.Domain.Repos;

namespace GameExChange.Repository.EntityRepos
{
    /// <summary>
    /// 用户仓储实现
    /// </summary>
    public class UserRepository : EntityFramework.EntityFrameworkRepository<DomainModel.User>, DomainRepo.IUserRepository
    {

        public UserRepository(DomainRepo.IRepositoryContext context)
            : base(context)
        {
        }


    }
}
