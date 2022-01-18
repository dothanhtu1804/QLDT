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
    public class PhieuMuaController : Controller
    {
        DiDongPortalEntities2 data = new DiDongPortalEntities2();
        // GET: PhieuMua
        public ActionResult Index(int? page)
        {
            int pageSize = 4;
            int pageNum = (page ?? 1);
            var ListDT = data.PhieuMuas.OrderByDescending(x => x.IdPM);
            return View(ListDT.ToPagedList(pageNum, pageSize));
        }

        public ActionResult IndexAdmin()
        {
            return View(data.PhieuMuas.ToList());
        }

        public ActionResult IndexShip(int? page)
        {
            int pageSize = 4;
            int pageNum = (page ?? 1);
            var ListDT = data.PhieuMuas.OrderByDescending(x => x.IdPM);
            return View(ListDT.ToPagedList(pageNum, pageSize));
        }
        // GET: PhieuMua/Details/5
        public ActionResult Details(int id)
        {
            return View(data.PhieuMuas.Where(x=>x.IdPM==id).FirstOrDefault());
        }

        // GET: PhieuMua/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PhieuMua/Create
        [HttpPost]
        public ActionResult Create(PhieuMua pm)
        {
            try
            {
                // TODO: Add insert logic here
                data.PhieuMuas.Add(pm);
                data.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: PhieuMua/Edit/5
        public ActionResult Edit(int id)
        {
            return View(data.PhieuMuas.Where(x => x.IdPM == id).FirstOrDefault());
        }

        // POST: PhieuMua/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, PhieuMua pm)
        {
            try
            {
                // TODO: Add update logic here
               
                data.Entry(pm).State = System.Data.Entity.EntityState.Modified;
                data.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Nhandon(int id)
        {
            return View(data.PhieuMuas.Where(x => x.IdPM == id).FirstOrDefault());
        }

        // POST: PhieuMua/Edit/5
        [HttpPost]
        public ActionResult Nhandon(int id, PhieuMua pm)
        {
            try
            {
                // TODO: Add update logic here

                data.Entry(pm).State = System.Data.Entity.EntityState.Modified;
                data.SaveChanges();
                return RedirectToAction("IndexShip","PhieuMua");
            }
            catch
            {
                return View();
            }
        }

        // GET: PhieuMua/Delete/5
        public ActionResult Delete(int id)
        {
            return View(data.PhieuMuas.Where(x => x.IdPM == id).FirstOrDefault());
        }

        // POST: PhieuMua/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, PhieuMua pm)
        {
            try
            {
                // TODO: Add delete logic here
                pm = data.PhieuMuas.Where(x => x.IdPM == id).FirstOrDefault();
                data.PhieuMuas.Remove(pm);
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
