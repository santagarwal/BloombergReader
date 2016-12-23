using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BloombergReaderWeb.Models;

namespace BloombergReaderWeb.Controllers
{
    public class IntradayBarTableController : Controller
    {
        // GET: IntradayBarTable
        public ActionResult Index()
        {
            var bars = new List<Bar>
            {
                new Bar()
                {
                    Date = DateTime.Now,
                    Open = 12.3m,
                    Close = 11.3m,
                    High = 15.4m,
                    Low = 3.2m,
                    Volume = 15
                },
                new Bar()
                {
                    Date = DateTime.Now,
                    Open = 15.3m,
                    Close = 13.3m,
                    High = 16.4m,
                    Low = 3.1m,
                    Volume = 18
                },
                new Bar()
                {
                    Date = DateTime.Now,
                    Open = 13.3m,
                    Close = 15.3m,
                    High = 19.4m,
                    Low = 3.2m,
                    Volume = 19
                }
            };

            return View(bars);
        }
    }
}