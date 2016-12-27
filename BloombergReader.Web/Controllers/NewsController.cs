using BloombergReader.Core.BloombergRequests;
using BloombergReader.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BloombergReader.Web.Controllers
{
    public class NewsController : Controller
    {
        private static List<Story> _stories;

        static NewsController()
        {
            _stories = new NewsRequest().GetNews();
        }

        public ActionResult ReadNews()
        {
            return View(_stories);
        }

        [HttpPost]
        public ActionResult ReadNews(Story story)
        {
            _stories.Add(story);
            return View(_stories);
        }
    }
}