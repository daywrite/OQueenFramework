using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using Autofac.Integration.WebApi;
using System.Web.Http;
using System.Reflection;
using OQueen.Core;
using OQueen.Application;
using OQueen.Core.Data.Entity;
namespace OQueen.WebApi.Ioc
{
    /// <summary>
    /// Ioc依赖注入的静态类
    /// </summary>
    public static class Bootstrapper
    {
        /// <summary>
        /// 静态方法
        /// </summary>
        public static void Run()
        {
            SetAutofacWebApi();
        }

        private static void SetAutofacWebApi()
        {
            var configuration = GlobalConfiguration.Configuration;
            var builder = new ContainerBuilder();

            var baseType = typeof(IDependency);
            var assemblys = AppDomain.CurrentDomain.GetAssemblies().ToList();
            // Register API controllers using assembly scanning.
            builder.RegisterApiControllers(assemblys.ToArray());
            //builder.RegisterType<DemoService>().As<IDemoContract>().InstancePerApiRequest();
            //builder.RegisterType<CodeFirstDbContext>().As<IUnitOfWork>().InstancePerApiRequest();
            builder.RegisterAssemblyTypes(assemblys.ToArray())
                .Where(t => baseType.IsAssignableFrom(t) && t != baseType)
                .AsImplementedInterfaces().InstancePerLifetimeScope();

            var container = builder.Build();
            // Set the dependency resolver implementation.
            var resolver = new AutofacWebApiDependencyResolver(container);
            configuration.DependencyResolver = resolver;
        }
    }
}