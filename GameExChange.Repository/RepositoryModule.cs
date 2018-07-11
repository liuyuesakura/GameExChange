using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using GameExChange.Infrastructure.Interface;
using GameExChange.Repository.Contract;
using GameExChange.Repository.EntityRepository;

namespace GameExChange.Repository
{
    public class RepositoryModule :Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EntityFramework.EntityFrameworkRepositoryContext>()
                .As<IUnitOfWork>()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(this.ThisAssembly)
                .Where(t => t.IsAssignableTo<IRepositoryMark>())
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
