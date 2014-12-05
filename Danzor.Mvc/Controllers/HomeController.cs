using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Danzor.Print;

namespace Danzor.Mvc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string path = HttpContext.Server.MapPath("~/Content/NFe28090708060730000190550020000001762000007303procNFe.xml");
            DanzorPrintViewer model = new DanzorPrintViewer(path);

            return View("~/Views/Danfe/Danfe.cshtml", model); 
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}