using System.Reflection;
using System.Web.Mvc;
using BloombergReader.Core.Logging;

namespace BloombergReader.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Logger.Instance.InfoFormat(
                @"Controller: {0}; ActionResult: {1}",
                GetType(), MethodBase.GetCurrentMethod());

            return View();
        }

        public ActionResult About()
        {
            Logger.Instance.InfoFormat(
                @"Controller: {0}; ActionResult: {1}",
                GetType(), MethodBase.GetCurrentMethod());

            return View();
        }
        
    }
}