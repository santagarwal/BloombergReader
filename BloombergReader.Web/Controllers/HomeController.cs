using System.Web.Mvc;
using BloombergReader.Core.Logging;

namespace BloombergReader.Web.Controllers
{
    public class HomeController : Controller
    {
        [LoggingFilter]
        public ActionResult Index()
        {
            return View();
        }

        [LoggingFilter]
        public ActionResult About()
        {
            return View();
        }
        
    }
}