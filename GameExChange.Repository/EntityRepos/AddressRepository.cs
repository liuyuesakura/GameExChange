using DomainModel = GameExChange.Domain.Model;
using DomainRepo = GameExChange.Domain.Repos;

namespace GameExChange.Repository.EntityRepos
{
    /// <summary>
    /// 收件地址仓储实现
    /// </summary>
    public class AddressRepository : EntityFramework.EntityFrameworkRepository<DomainModel.Address>, DomainRepo.IAddressRepository
    {

        public AddressRepository(DomainRepo.IRepositoryContext context)
            : base(context)
        {

        }


    }
}