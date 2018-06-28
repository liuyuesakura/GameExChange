using System;
using System.Collections.Generic;
using System.Text;
using GameExChange.Infrastructure;

namespace GameExChange.Domain.Repos
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
