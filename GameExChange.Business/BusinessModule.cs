using System;
using System.Collections.Generic;
using System.Text;
using Autofac;

namespace GameExChange.Business
{
    public class BusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(this.ThisAssembly)
                .Where(t => t.IsAssignableTo<IBusinessMark>())
                .AsImplementedInterfaces()
                .AsSelf()
                .InstancePerLifetimeScope();
        }

    }
}
