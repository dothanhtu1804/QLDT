using demoTMDT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using PagedList;
using PagedList.Mvc;
using System.Data;

namespace demoTMDT.Controllers
{
    public class DienThoaiController : Controller
    {
        DiDongPortalEntities2 data = new DiDongPortalEntities2();
        // GET: DienThoai
        public ActionResult Index(int? page )
        {
            int pageSize = 3;
            int pageNum = (page ?? 1);
            var ListDT = data.DienThoais.OrderByDescending(x=>x.IdDT);
            return View(ListDT.ToPagedList(pageNum,pageSize));
        }

        public ActionResult IndexAdmin()
        {
            return View(data.DienThoais.ToList());
        }

        public ActionResult DSDT(int? page)
        {
            int pageSize = 3;
            int pageNum = (page ?? 1);
            var ListDT = data.DienThoais.OrderByDescending(x => x.IdDT);
            return View(ListDT.ToPagedList(pageNum, pageSize));
        }

        // GET: DienThoai/Details/5
        public ActionResult Details(int id)
        {
            return View(data.DienThoais.Where(s => s.IdDT == id).FirstOrDefault());
        }

        public ActionResult Create()
        {
            DienThoai dienThoai = new DienThoai();
            return View(dienThoai);
        }

        // POST: DienThoai/Create
        [HttpPost]
        public ActionResult Create(DienThoai dienThoai)
        {
            if (dienThoai.UploadImage1 != null || dienThoai.UploadImage2 != null || dienThoai.UploadImage3 != null)
            {

                //hinh1
                string filename1 = Path.GetFileNameWithoutExtension(dienThoai.UploadImage1.FileName);
                string ex1 = Path.GetExtension(dienThoai.UploadImage1.FileName);

                //hinh2
                string filename2 = Path.GetFileNameWithoutExtension(dienThoai.UploadImage2.FileName);
                string ex2 = Path.GetExtension(dienThoai.UploadImage2.FileName);
                //hinh3
                string filename3 = Path.GetFileNameWithoutExtension(dienThoai.UploadImage3.FileName);
                string ex3 = Path.GetExtension(dienThoai.UploadImage3.FileName);
                filename1 = filename1 + ex1;

                filename2 = filename2 + ex2;

                filename3 = filename3 + ex3;

                dienThoai.hinh1 = "~/Content/Image/" + filename1;
                dienThoai.hinh2 = "~/Content/Image/" + filename2;
                dienThoai.hinh3 = "~/Content/Image/" + filename3;

                dienThoai.UploadImage1.SaveAs(Path.Combine(Server.MapPath("~/Content/Image/"), filename1));
                dienThoai.UploadImage2.SaveAs(Path.Combine(Server.MapPath("~/Content/Image/"), filename2));
                dienThoai.UploadImage3.SaveAs(Path.Combine(Server.MapPath("~/Content/Image/"), filename3));
            }
            // ViewBag.listcate = new SelectList(list, "IDCate", "NameCate", 1);
            data.DienThoais.Add(dienThoai);
            data.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: DienThoai/Edit/5
        public ActionResult Edit(int id)
        {
            return View(data.DienThoais.Where(s => s.IdDT == id).FirstOrDefault());
        }

        // POST: DienThoai/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, DienThoai dt)
        {
            try
            {
                // TODO: Add update logic here
                data.Entry(dt).State = System.Data.Entity.EntityState.Modified;
                data.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: DienThoai/Delete/5
        public ActionResult Delete(int id)
        {
            return View(data.DienThoais.Where(s => s.IdDT == id).FirstOrDefault());
        }

        // POST: DienThoai/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, DienThoai dt)
        {
            try
            {
                // TODO: Add delete logic here
                dt = data.DienThoais.Where(s => s.IdDT == id).FirstOrDefault();
                data.DienThoais.Remove(dt);
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
