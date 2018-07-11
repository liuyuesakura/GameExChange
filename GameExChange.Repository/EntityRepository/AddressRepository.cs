using GameExChange.Entity;
using GameExChange.Repository.Contract;

namespace GameExChange.Repository.EntityRepository
{
    /// <summary>
    /// 收件地址仓储实现
    /// </summary>
    public class AddressRepository : EntityFramework.EntityFrameworkRepository<Address>, IAddressRepository,IRepositoryMark
    {

        public AddressRepository(IRepositoryContext context)
            : base(context)
        {

        }


    }
}