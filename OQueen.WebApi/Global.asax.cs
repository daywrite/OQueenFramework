#region 头部注释
// -----------------------------------------------------------------------
//  文件名称： "Global.asax.cs"
//  公司名称：北京思路华清信息技术有限公司
//  作者：李文彬
//  创建时间：2014-07-28 18:00
//  版本：V1.0
// -----------------------------------------------------------------------
//          修改人     |       修改时间
// -----------------------------------------------------------------------
//                     |
// -----------------------------------------------------------------------
#endregion
using Autofac;
using OQueen.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac.Integration.WebApi;
using OQueen.WebApi.Ioc;
using OQueen.Core.Data.Entity;
using System.Reflection;
namespace OQueen.WebApi
{
    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
 
            //Autofac的注册
            Bootstrapper.Run();
            //DataBase的生成
            DatabaseInitializer.Initialize();
        }
    }
}