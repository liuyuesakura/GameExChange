using GameExChange.Infrastructure;
using GameExChange.Infrastructure.Interface;
using System;

namespace GameExChange.Repository.Contract
{
    /// <summary>
    /// 仓储上下文接口
    /// </summary>
    public interface IRepositoryContext : IUnitOfWork
    {
        Guid ID { get; }

        void RegisterNew<TAggregateRoot>(TAggregateRoot entity)
            where TAggregateRoot : class, IAggregateRoot;

        void RegisterModify<TAggregateRoot>(TAggregateRoot entity)
            where TAggregateRoot : class, IAggregateRoot;

        void RegisterDelete<TAggregateRoot>(TAggregateRoot entity)
            where TAggregateRoot : class, IAggregateRoot;
    }
}
