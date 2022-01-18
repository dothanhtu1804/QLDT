using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using demoTMDT.Models;
using PagedList;
using PagedList.Mvc;

namespace demoTMDT.Controllers
{
    public class LichNhapController : Controller
    {
        DiDongPortalEntities2 data = new DiDongPortalEntities2();
        // GET: LichNhap
        public ActionResult Index(int? page)
        {
            int pageSize = 3;
            int pageNum = (page ?? 1);
            var ListDT = data.LichNhaps.OrderByDescending(x => x.IdLichNhap);
            return View(ListDT.ToPagedList(pageNum, pageSize));
        }

        public ActionResult IndexAdmin()
        {
            return View(data.LichNhaps.ToList());
        }

        public ActionResult DSNhap()
        {
            return View(data.LichNhaps.ToList());
        }

        // GET: LichNhap/Details/5
        public ActionResult Details(int id)
        {
            return View(data.LichNhaps.Where(s => s.IdLichNhap == id).FirstOrDefault());
        }

        // GET: LichNhap/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LichNhap/Create
        [HttpPost]
        public ActionResult Create(LichNhap lich)
        {
            try
            {
                // TODO: Add insert logic here
                data.LichNhaps.Add(lich);
                data.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: LichNhap/Edit/5
        public ActionResult Edit(int id)
        {
            return View(data.LichNhaps.Where(s => s.IdLichNhap == id).FirstOrDefault());
        }

        // POST: LichNhap/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, LichNhap l)
        {
            try
            {
                // TODO: Add update logic here
                data.Entry(l).State = System.Data.Entity.EntityState.Modified;
                data.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: LichNhap/Delete/5
        public ActionResult Delete(int id)
        {
            return View(data.LichNhaps.Where(s => s.IdLichNhap == id).FirstOrDefault());
        }

        // POST: LichNhap/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, LichNhap l)
        {
            try
            {
                // TODO: Add delete logic here
                l = data.LichNhaps.Where(s => s.IdLichNhap == id).FirstOrDefault();
                data.LichNhaps.Remove(l);
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
