using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using demoTMDT.Models;
using System.Web.Mvc;

namespace demoTMDT.Controllers
{
    public class BaoHanhController : Controller
    {
        DiDongPortalEntities2 data = new DiDongPortalEntities2();
        // GET: BaoHanh
        public ActionResult Index()
        {
            return View(data.BaoHanhs.ToList());
        }

        // GET: BaoHanh/Details/5
        public ActionResult Details(int id)
        {
            return View(data.BaoHanhs.Where(s=>s.IdBaoHanh == id).FirstOrDefault());
        }

        // GET: BaoHanh/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BaoHanh/Create
        [HttpPost]
        public ActionResult Create(BaoHanh bh)
        {
            try
            {
                // TODO: Add insert logic here
                data.BaoHanhs.Add(bh);
                data.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: BaoHanh/Edit/5
        public ActionResult Edit(int id)
        {
            return View(data.BaoHanhs.Where(s => s.IdBaoHanh == id).FirstOrDefault());
        }

        // POST: BaoHanh/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, BaoHanh bh)
        {
            try
            {
                // TODO: Add update logic here
                data.Entry(bh).State = System.Data.Entity.EntityState.Modified;
                data.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: BaoHanh/Delete/5
        public ActionResult Delete(int id)
        {
            return View(data.BaoHanhs.Where(s => s.IdBaoHanh == id).FirstOrDefault());
        }

        // POST: BaoHanh/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, BaoHanh bh)
        {
            try
            {
                // TODO: Add delete logic here
                bh = data.BaoHanhs.Where(s => s.IdBaoHanh == id).FirstOrDefault();
                data.BaoHanhs.Remove(bh);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
