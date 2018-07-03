using System;
using System.Collections.Generic;
using System.Text;
using GameExChange.Domain.Repos;

namespace GameExChange.Business
{
    public abstract class ApplicationService
    {
        private readonly IRepositoryContext _repositoryContext;

        protected ApplicationService(IRepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        protected IRepositoryContext RepositoryContext
        {
            get { return this._repositoryContext; }
        }
    }
}
