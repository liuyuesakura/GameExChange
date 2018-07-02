using System;
using System.Collections.Generic;
using System.Text;

using GameExChange.Domain;
using DomainRepo = GameExChange.Domain.Repos;
using DomainModel = GameExChange.Domain.Model;

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