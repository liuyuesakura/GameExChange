using System.Data.Common;

namespace GameExChange.Infrastructure.Interface
{
    public interface IUnitOfWork
    {
        void Commit();

        void CommitAsync();

        DbTransaction BeginTranscation();

        void CommitTranscation();

        void RollbackTranscation();
    }
}
