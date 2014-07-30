using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using Autofac.Integration.WebApi;
using System.Web.Http;
using System.Reflection;
using OQueen.Core;
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

            // Register API controllers using assembly scanning.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            //builder.RegisterType<OQueen.WebApi.Controllers.ValuesController.TestService>().As<OQueen.WebApi.Controllers.ValuesController.ITestContract>().InstancePerApiRequest();
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .Where(t => baseType.IsAssignableFrom(t) && t != baseType)
                .AsImplementedInterfaces().InstancePerLifetimeScope();

            var container = builder.Build();
            // Set the dependency resolver implementation.
            var resolver = new AutofacWebApiDependencyResolver(container);
            configuration.DependencyResolver = resolver;
        }
    }
}