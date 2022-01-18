using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using demoTMDT.Models;

namespace demoTMDT.Controllers
{
    public class HomeController : Controller
    {
        DiDongPortalEntities2 data = new DiDongPortalEntities2();
        public ActionResult Index()
        {
            return View(data.DienThoais.Take(4).OrderByDescending(x => x.IdDT).ToList());
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