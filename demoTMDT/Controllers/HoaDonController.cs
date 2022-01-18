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
    public class HoaDonController : Controller
    {
        DiDongPortalEntities2 data = new DiDongPortalEntities2();
        // GET: HoaDon
        public ActionResult Index(int? page)
        {
            int pageSize = 3;
            int pageNum = (page ?? 1);
            var ListDT = data.HoaDons.OrderByDescending(x => x.IdHoaDon);
            return View(ListDT.ToPagedList(pageNum, pageSize));
        }

        public ActionResult IndexShip(int? page)
        {
            int pageSize = 3;
            int pageNum = (page ?? 1);
            var ListDT = data.HoaDons.OrderByDescending(x => x.IdHoaDon);
            return View(ListDT.ToPagedList(pageNum, pageSize));
        }

        public ActionResult TimKiem(string _name)
        {
            var listtk = data.HoaDons.Where(p => p.SĐT.Contains(_name)).ToList();
            return View(listtk);
        }
        // GET: HoaDon/Details/5
        public ActionResult Details(int id)
        {
            return View(data.HoaDons.Where(s => s.IdHoaDon == id).FirstOrDefault());
        }

        // GET: HoaDon/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HoaDon/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: HoaDon/Edit/5
        public ActionResult Edit(int id)
        {
            return View(data.HoaDons.Where(s=>s.IdHoaDon == id).FirstOrDefault());
        }

        // POST: HoaDon/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, HoaDon hd)
        {
            try
            {
                // TODO: Add update logic here
                data.Entry(hd).State = System.Data.Entity.EntityState.Modified;
                data.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: HoaDon/Delete/5
        public ActionResult Delete(int id)
        {
            return View(data.HoaDons.Where(s => s.IdHoaDon == id).FirstOrDefault());
        }

        // POST: HoaDon/Delete/5
        [HttpPost]
        public ActionResult Delete(int id,HoaDon hd)
        {
            try
            {
                // TODO: Add delete logic here
                hd = data.HoaDons.Where(s => s.IdHoaDon == id).FirstOrDefault();
                data.HoaDons.Remove(hd);
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
