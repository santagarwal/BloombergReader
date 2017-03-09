using BloombergReader.Core.Logging;
using BloombergReader.Core.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BloombergReader.Web.Controllers
{
    public class GalleryController : Controller
    {
        private string _serverUrl = "~/Images/Gallery";

        private IEnumerable<Image> GetImages()
        {
            var results = new List<Image>();

            string path = Server.MapPath(_serverUrl);

            foreach (var item in Directory.GetFiles(path))
            {
                string fileName = Path.GetFileName(item);
                string fileUrl = $"{_serverUrl}/{fileName}";

                results.Add(new Image()
                {
                    Path = fileUrl,
                    Description = fileName
                });
            }

            return results;
        }

        [LoggingFilter]
        public ActionResult Gallery()
        {
            return View(GetImages());
        }

        [LoggingFilter]
        [HttpPost]
        public ActionResult Gallery(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
                try
                {
                    string path = Path.Combine(Server.MapPath(_serverUrl),
                                               Path.GetFileName(file.FileName));
                    file.SaveAs(path);
                    ViewBag.Message = "File uploaded successfully";
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "ERROR:" + ex.Message.ToString();
                }
            else
            {
                ViewBag.Message = "You have not specified a file.";
            }

            return View(GetImages());
        }
    }
}