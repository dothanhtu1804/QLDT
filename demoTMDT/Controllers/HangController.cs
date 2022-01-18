using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using demoTMDT.Models;

namespace demoTMDT.Controllers
{
    public class HangController : Controller
    {
        DiDongPortalEntities2 data = new DiDongPortalEntities2();
        // GET: Hang
        public ActionResult Index()
        {
            return View(data.Hangs.ToList());
        }

        // GET: Hang/Details/5
        public ActionResult Details(string id)
        {
            return View(data.Hangs.Where(s => s.IdHang == id).FirstOrDefault());
        }

        // GET: Hang/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Hang/Create
        [HttpPost]
        public ActionResult Create(Hang h)
        {
            try
            {
                // TODO: Add insert logic here
                data.Hangs.Add(h);
                data.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Hang/Edit/5
        public ActionResult Edit(string id)
        {
            return View(data.Hangs.Where(s => s.IdHang == id).FirstOrDefault());
        }

        // POST: Hang/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, BaoHanh h)
        {
            try
            {
                // TODO: Add update logic here
                data.Entry(h).State = System.Data.Entity.EntityState.Modified;
                data.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Hang/Delete/5
        public ActionResult Delete(string id)
        {
            return View(data.Hangs.Where(s => s.IdHang == id).FirstOrDefault());
        }

        // POST: Hang/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, Hang h)
        {
            try
            {
                // TODO: Add delete logic here
                h = data.Hangs.Where(s => s.IdHang == id).FirstOrDefault();
                data.Hangs.Remove(h);
                data.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public PartialViewResult HangPartial()
        {
            var Hanglist = data.Hangs.ToList();
            return PartialView(Hanglist);
        }
    }
}
