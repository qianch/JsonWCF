using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using QCWService.Infrastructure.Repositories;
using QCWService.Domain.FrameUserAggregate;
using Autofac.Extras.DynamicProxy;
using QCService.Interceptor;
using Castle.DynamicProxy;

namespace QCWService.Infrastructure.AutofacModules
{
    public class ApplicationModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AuthorizeInterceptor>()
                .As<AuthorizeInterceptor>()
                .InstancePerLifetimeScope();

            builder.RegisterType<FrameUserRepository>()
                .As<IFrameUserRepository>()
                .InstancePerLifetimeScope()
                .EnableInterfaceInterceptors()
                .InterceptedBy(typeof(AuthorizeInterceptor));

            builder.RegisterType<FrameContext>()
                .As<FrameContext>()
                .InstancePerLifetimeScope()
                .EnableClassInterceptors()
                .InterceptedBy(typeof(AuthorizeInterceptor));
        }
    }
}