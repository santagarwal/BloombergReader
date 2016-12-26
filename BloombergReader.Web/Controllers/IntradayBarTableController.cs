using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using BloombergReader.Core.BloombergRequests;
using BloombergReader.Core.Logging;
using BloombergReader.Core.Models;

namespace BloombergReader.Web.Controllers
{
    public class IntradayBarTableController : Controller
    {
        // GET: IntradayBarTable
        public ActionResult Index()
        {
            Logger.Instance.InfoFormat(
                @"Controller: {0}; ActionResult: {1}",
                GetType(), MethodBase.GetCurrentMethod());

            var bloombergRequest = new IntradayBarDataRequest("SPY US EQUITY");
            return View(bloombergRequest.GetBars() ?? Enumerable.Empty<Bar>());
        }
    }
}