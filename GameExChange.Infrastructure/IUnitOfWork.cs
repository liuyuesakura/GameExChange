using System;

namespace GameExChange.Infrastructure
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
