using System.Web.Mvc;
using System.Web.Routing;
using BloombergReader.Core.Logging;

namespace BloombergReader.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // TODO: refactor to aspects
            Logger.Instance.Info("BloomberReader starting...");

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
        }
    }
}
