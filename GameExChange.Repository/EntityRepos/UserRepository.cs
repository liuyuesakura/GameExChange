using System;
using System.Collections.Generic;
using System.Text;

using GameExChange.Domain;
using DomainRepo = GameExChange.Domain.Repos;
using DomainModel = GameExChange.Domain.Model;
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
