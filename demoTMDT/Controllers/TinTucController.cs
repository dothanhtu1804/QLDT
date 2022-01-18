using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using demoTMDT.Models;

namespace demoTMDT.Controllers
{
    public class TinTucController : Controller
    {
        DiDongPortalEntities2 data = new DiDongPortalEntities2();
        // GET: TinTuc
        public ActionResult Index()
        {
            return View(data.TinTucs.ToList());
        }

        public ActionResult DS_TT()
        {
            return View(data.TinTucs.ToList());
        }

        public ActionResult CT_TT(int id)
        {
            return View(data.TinTucs.Where(s => s.IdTinTuc == id).FirstOrDefault());
        }

        // GET: TinTuc/Details/5
        public ActionResult Details(int id)
        {
            return View(data.TinTucs.Where(s=>s.IdTinTuc == id).FirstOrDefault());
        }

        // GET: TinTuc/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TinTuc/Create
        [HttpPost]
        public ActionResult Create(TinTuc t)
        {
            
                // TODO: Add insert logic here
                data.TinTucs.Add(t);
                data.SaveChanges();
                return RedirectToAction("Index","TinTuc");
            
        }

        // GET: TinTuc/Edit/5
        public ActionResult Edit(int id)
        {
            return View(data.TinTucs.Where(s => s.IdTinTuc == id).FirstOrDefault());
        }

        // POST: TinTuc/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, TinTuc t)
        {
            try
            {
                // TODO: Add update logic here
                data.Entry(t).State = System.Data.Entity.EntityState.Modified;
                data.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TinTuc/Delete/5
        public ActionResult Delete(int id)
        {
            return View(data.TinTucs.Where(s => s.IdTinTuc == id).FirstOrDefault());
        }

        // POST: TinTuc/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, TinTuc t)
        {
            try
            {
                // TODO: Add delete logic here
                t = data.TinTucs.Where(s => s.IdTinTuc == id).FirstOrDefault();
                data.TinTucs.Remove(t);
                data.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
