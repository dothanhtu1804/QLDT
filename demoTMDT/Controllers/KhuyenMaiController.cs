using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using demoTMDT.Models;
using System.IO;

namespace demoTMDT.Controllers
{
    public class KhuyenMaiController : Controller
    {
        DiDongPortalEntities2 data = new DiDongPortalEntities2();
        // GET: KhuyenMai
        public ActionResult Index()
        {
            return View(data.KhuyenMais.ToList());
        }
        public ActionResult DS_KM()
        {
            return View(data.KhuyenMais.ToList());
        }
        // GET: KhuyenMai/Details/5
        public ActionResult Details(int id)
        {
            return View(data.KhuyenMais.Where(s => s.IdKM == id).FirstOrDefault());
        }

        // GET: KhuyenMai/Create
        public ActionResult Create()
        {
            KhuyenMai km = new KhuyenMai();
            return View(km);
        }

        // POST: KhuyenMai/Create
        [HttpPost]
        public ActionResult Create(KhuyenMai km)
        {
            if (km.UploadImage != null)
            {
                string filename = Path.GetFileNameWithoutExtension(km.UploadImage.FileName);
                string ex = Path.GetExtension(km.UploadImage.FileName);
                filename = filename + ex;
                km.HinhAnh = "~/Content/Image/" + filename;
                km.UploadImage.SaveAs(Path.Combine(Server.MapPath("~/Content/Image/"), filename));

            }
               data.KhuyenMais.Add(km);
                data.SaveChanges();
                return RedirectToAction("Index");
           
        }

        // GET: KhuyenMai/Edit/5
        public ActionResult Edit(int id)
        {
            KhuyenMai km = new KhuyenMai();
            return View(data.KhuyenMais.Where(s => s.IdKM == id).FirstOrDefault());
        }

        // POST: KhuyenMai/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, KhuyenMai km)
        {
            
                // TODO: Add update logic here
                data.Entry(km).State = System.Data.Entity.EntityState.Modified;
                data.SaveChanges();
                return RedirectToAction("Index");
            
           
        }

        // GET: KhuyenMai/Delete/5
        public ActionResult Delete(int id)
        {
            return View(data.KhuyenMais.Where(s => s.IdKM == id).FirstOrDefault());
        }

        // POST: KhuyenMai/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, KhuyenMai km)
        {
            try
            {
                // TODO: Add delete logic here
                km = data.KhuyenMais.Where(s => s.IdKM == id).FirstOrDefault();
                data.KhuyenMais.Remove(km);
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
