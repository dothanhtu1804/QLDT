using demoTMDT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace demoTMDT.Controllers
{
    public class KhachHangController : Controller
    {
         DiDongPortalEntities2 data = new DiDongPortalEntities2();
        // GET: KhachHang
        public ActionResult Index()
        {
            return View(data.KhachHangs.ToList());
        }

        // GET: KhachHang/Details/5
        public ActionResult Details(int id)
        {
            return View(data.KhachHangs.Where(s => s.IdKH == id).FirstOrDefault());
        }

        // GET: KhachHang/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: KhachHang/Create
        [HttpPost]
        public ActionResult Create(KhachHang KH)
        {
            try
            {
                // TODO: Add insert logic here
                data.KhachHangs.Add(KH);
                data.SaveChanges();
                return RedirectToAction("Index","KhachHang");
            }
            catch
            {
                return View();
            }
        }

        // GET: KhachHang/Edit/5
        public ActionResult Edit(int id)
        {
            return View(data.KhachHangs.Where(s => s.IdKH == id).FirstOrDefault());
        }

        // POST: KhachHang/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, KhachHang kh)
        {
            try
            {
                // TODO: Add update logic here
                data.Entry(kh).State = System.Data.Entity.EntityState.Modified;
                data.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: KhachHang/Delete/5
        public ActionResult Delete(int id)
        {
            return View(data.KhachHangs.Where(s => s.IdKH == id).FirstOrDefault());
        }

        // POST: KhachHang/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, KhachHang kh)
        {
            try
            {
                // TODO: Add delete logic here
                kh = data.KhachHangs.Where(s => s.IdKH == id).FirstOrDefault();
                data.KhachHangs.Remove(kh);
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
