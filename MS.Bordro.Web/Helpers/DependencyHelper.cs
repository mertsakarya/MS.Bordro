using System;
using System.Configuration;
using System.Web;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using MS.Bordro.Infrastructure.Cache;
using MS.Bordro.Interfaces.Repositories;
using MS.Bordro.Interfaces.Services;
using MS.Bordro.Repositories.DB;
using MS.Bordro.Services;
using NLog;

namespace MS.Bordro.Web.Helpers
{
    public static class DependencyHelper
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        public const int GlobalPageSize = 10;
        public static IContainer Container;
        public static readonly string PhotosFolder = HttpContext.Current.Server.MapPath("~/Photos");

        public static void RegisterDependencies()
        {
            var builder = new ContainerBuilder();
            
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<BordroDbContext>().As<IBordroDbContext>().InstancePerHttpRequest();

            builder.RegisterType<ResourceService>().As<IResourceService>().InstancePerHttpRequest();
            builder.RegisterType<CompanyRepositoryDB>().As<ICompanyRepositoryDB>().InstancePerHttpRequest();
            builder.RegisterType<CompanyLocationRepositoryDB>().As<ICompanyLocationRepositoryDB>().InstancePerHttpRequest();
            builder.RegisterType<UserRepositoryDB>().As<IUserRepositoryDB>().InstancePerHttpRequest();

            builder.RegisterType<UserService>().As<IUserService>().InstancePerHttpRequest();
            builder.RegisterType<UtilityService>().As<IUtilityService>().InstancePerHttpRequest();
            builder.RegisterType<SamplesService>().As<ISamplesService>().InstancePerHttpRequest();
            builder.RegisterType<CompanyService>().As<ICompanyService>().InstancePerHttpRequest();
            builder.RegisterType<CompanyLocationService>().As<ICompanyLocationService>().InstancePerHttpRequest();

            var cacheProviderText = ConfigurationManager.AppSettings["CacheProvider"];
            if (!String.IsNullOrWhiteSpace(cacheProviderText)) {
                switch(cacheProviderText.ToLowerInvariant()) {
                    //case "redis":
                    //    builder.RegisterType<BordroGlobalRedisCacheContext>().WithParameter(new TypedParameter(typeof(IBordroGlobalCacheContext), null)).As<IBordroGlobalCacheContext>().InstancePerHttpRequest();
                    //    break;
                    //case "ravendb":
                    //    builder.RegisterType<BordroGlobalRavenCacheContext>().WithParameter(new TypedParameter(typeof(IBordroGlobalCacheContext), null)).As<IBordroGlobalCacheContext>().InstancePerHttpRequest();
                    //    break;
                    default:
                        builder.RegisterType<BordroGlobalMemoryCacheContext>().WithParameter(new TypedParameter(typeof(IBordroGlobalCacheContext), null)).As<IBordroGlobalCacheContext>().InstancePerHttpRequest();
                        break;
                }

            } else {
                builder.RegisterType<BordroGlobalMemoryCacheContext>().As<IBordroGlobalCacheContext>().InstancePerHttpRequest();
            }
            Container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(Container));

#if DEBUG
            Logger.Info("Dependencies resolved");
#endif
        }
    }
}