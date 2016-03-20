using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Http.Tracing;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Linq;

namespace PlayEndomondoOnGoogleMaps.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Coords = "";
            return View();
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file)
        {
            ViewBag.Coords = "";
            if (file != null && file.ContentLength > 0)
            {
                var root = XElement.Load(file.InputStream);
                var ns = $"{{{root.GetDefaultNamespace().NamespaceName}}}";
                var elements = root.Elements(ns + "trk").Elements(ns + "trkseg").Elements(ns + "trkpt").ToList();
                var stringElements = elements.Select(e => $"{{lat:{e.Attribute("lat").Value},lng:{e.Attribute("lon").Value}}}");
                ViewBag.Coords = $"[{string.Join(",", stringElements)}]";
            }

            return View();
        }



    }
}