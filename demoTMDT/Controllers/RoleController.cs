using demoTMDT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace demoTMDT.Controllers
{
    public class RoleController : Controller
    {
        DiDongPortalEntities2 data = new DiDongPortalEntities2();
        // GET: Role
        public ActionResult Index()
        {
            return View(data.Roles.ToList());
        }

        // GET: Role/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Role/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Role/Create
        [HttpPost]
        public ActionResult Create(Role role)
        {
            try
            {
                // TODO: Add insert logic here
                data.Roles.Add(role);
                data.SaveChanges();
                return RedirectToAction("Index","Role");
            }
            catch
            {
                return View();
            }
        }

        // GET: Role/Edit/5
        public ActionResult Edit(string id)
        {
            return View(data.Roles.Where(s => s.IDQuyen == id).FirstOrDefault());
        }

        // POST: Role/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, Role r)
        {
            try
            {
                // TODO: Add update logic here
                data.Entry(r).State = System.Data.Entity.EntityState.Modified;
                data.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Role/Delete/5
        public ActionResult Delete(string id)
        {
            return View(data.Roles.Where(s=>s.IDQuyen==id).FirstOrDefault());
        }

        // POST: Role/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, Role r)
        {
            try
            {
                // TODO: Add delete logic here
                r = data.Roles.Where(s => s.IDQuyen == id).FirstOrDefault();
                data.Roles.Remove(r);
                data.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public PartialViewResult RolePartial()
        {
            var rolelist = data.Roles.ToList();
            return PartialView(rolelist);
        }
    }
}
