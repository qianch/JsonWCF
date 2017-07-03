using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using QCWService.Infrastructure.Repositories;
using QCWService.Domain.FrameUserAggregate;

namespace QCWService.Infrastructure.AutofacModules
{
    public class ApplicationModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<FrameUserRepository>()
                .As<FrameUserRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<FrameContext>()
                .As<FrameContext>()
                .InstancePerLifetimeScope();

        }
    }
}