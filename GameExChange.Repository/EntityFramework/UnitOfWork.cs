using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using GameExChange.Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace GameExChange.Repository.EntityFramework
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly DbContext _context;

        public UnitOfWork(DbContext context)
        {
            _context = context;
        }

        public DbTransaction BeginTranscation()
        {
            _context.Database.BeginTransaction();
            return _context.Database.CurrentTransaction.GetDbTransaction();
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void CommitAsync()
        {
            _context.SaveChangesAsync();
        }

        public void CommitTranscation()
        {
            _context.SaveChanges();
            _context.Database.CommitTransaction();
        }

        public void RollbackTranscation()
        {
            _context.Database.RollbackTransaction();
        }
    }
}
