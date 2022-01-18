using demoTMDT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Cryptography;
using System.Text;


namespace demoTMDT.Controllers
{
    public class QLNhanVienController : Controller
    {
        private DiDongPortalEntities2 data = new DiDongPortalEntities2();
        // GET: QLNhanVien
        public ActionResult Index()
        {
            return View(data.NhanViens.ToList());
        }

        // GET: QLNhanVien/Details/5
        public ActionResult Details(int id)
        {
            return View(data.NhanViens.Where(s => s.IdNV == id).FirstOrDefault());
        }

        // GET: QLNhanVien/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: QLNhanVien/Create
        [HttpPost]
        public ActionResult Create(NhanVien nv)
        {
            // TODO: Add insert logic here
            // nv.TinhTrang = "Đang hoạt động";
          //  List<Role> list = data.Roles.ToList();

         //   ViewBag.listrole = new SelectList(list, "IDQuyen", "TenQuyen", 1);

            nv.MatKhau = Encrypt(nv.MatKhau);

            data.NhanViens.Add(nv);
            data.SaveChanges();

            return RedirectToAction("Index", "QLNhanVien");

        }

        // GET: QLNhanVien/Edit/5
        public ActionResult Edit(int id)
        {
            return View(data.NhanViens.Where(s => s.IdNV == id).FirstOrDefault());
        }

        // POST: QLNhanVien/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, NhanVien nv)
        {
            data.Entry(nv).State = System.Data.Entity.EntityState.Modified;
            nv.MatKhau = Encrypt(nv.MatKhau);
            data.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: QLNhanVien/Delete/5
        public ActionResult Delete(int id)
        {
            return View(data.NhanViens.Where(s => s.IdNV == id).FirstOrDefault());
        }

        // POST: QLNhanVien/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, NhanVien nv)
        {
            try
            {
                // TODO: Add delete logic here
                nv = data.NhanViens.Where(s => s.IdNV == id).FirstOrDefault();
                data.NhanViens.Remove(nv);
                data.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return Content("Vui lòng kiểm tra lại thông tin !");
            }
        }
        static string Encrypt(string value) //encrypt với MD5
        {
            using (MD5CryptoServiceProvider mds = new MD5CryptoServiceProvider())
            {
                UTF8Encoding utf8 = new UTF8Encoding();
                byte[] data = mds.ComputeHash(utf8.GetBytes(value));
                return Convert.ToBase64String(data);
            }
        }
     /*   public ActionResult SelectRole ()
        {
            Role r = new Role();
            r.Listrole = data.Roles.ToList<Role>();
            return PartialView(r);
        } */
    }
}
