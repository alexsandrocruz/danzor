using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Danzor.Mvc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Danzor.DanzorPrintViewer model = new DanzorPrintViewer(@"c:\NFe28090708060730000190550020000001762000007303procNFe.xml");

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