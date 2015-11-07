namespace Snippy.App
{
    using System.Data.Entity;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;
    using Snippy.App.App_Start;
    using Snippy.Data;
    using Snippy.Data.Migrations;

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SnippyDbContext, Configuration>());
            MapperConfig.CreateMappings();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
