using System.Linq;
using System.Web.Mvc;
using BloombergReader.Core.BloombergRequests;
using BloombergReader.Core.Logging;
using BloombergReader.Core.Models;

namespace BloombergReader.Web.Controllers
{
    public class IntradayBarTableController : Controller
    {
        // GET: IntradayBarTable
        [LoggingFilter]
        public ActionResult IntradayBarTable()
        {
            var bloombergRequest = new IntradayBarDataRequest("SPY US EQUITY");
            return View(bloombergRequest.GetBars() ?? Enumerable.Empty<Bar>());
        }
    }
}