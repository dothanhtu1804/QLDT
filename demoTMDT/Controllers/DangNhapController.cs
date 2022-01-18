using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using demoTMDT.Models;
using System.Security.Cryptography;
using System.Text;


namespace demoTMDT.Controllers
{
    public class DangNhapController : Controller
    {
        DiDongPortalEntities2 data = new DiDongPortalEntities2();
        // GET: DangNhap
        static string Encrypt(string value) //encrypt với MD5
        {
            using (MD5CryptoServiceProvider mds = new MD5CryptoServiceProvider())
            {
                UTF8Encoding utf8 = new UTF8Encoding();
                byte[] data = mds.ComputeHash(utf8.GetBytes(value));
                return Convert.ToBase64String(data);
            }
        }
        public ActionResult Loi()
        {
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult IndexAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginAdmin(NhanVien nhanVien)
        {
            string t = Encrypt(nhanVien.MatKhau);
            var check = data.NhanViens.Where(s => s.TaiKhoan == nhanVien.TaiKhoan && s.MatKhau == t).FirstOrDefault();
            if (check == null)
            {

                ViewBag.ErrorInfo = "Sai Info";
                return RedirectToAction("Loi","DangNhap");
            }
            else
            {
                data.Configuration.ValidateOnSaveEnabled = false;
                Session["TaiKhoan"] = nhanVien.TaiKhoan;

                Session["MatKhau"] = t;

                string admin = "Admin";
                string NVBanHang = "NV Bán Hàng";
                string NVQuanKho = "NV Kho";
                string NVship = "NV Ship";
                string NVCSKH = "NV CSKH";
                foreach (var user1 in data.NhanViens.Where(s => s.TaiKhoan == nhanVien.TaiKhoan && s.MatKhau == t))
                {

                    if (user1.TinhTrang != "Hoạt Động") // kiểm tra tình trạng account , nếu ko hoạt động thì ko cho login
                    {
                        return Content("<script language='javascript' type='text/javascript'>alert     ('Tài Khoản đã bị vô hiệu hóa!');</script>");
                    }

                    if (user1.IDQuyen == admin)//nếu duyệt trong database có tk và mk trùng khớp thì sẽ kt idrole và hiển thị giao diện của role đó
                    {
                        return RedirectToAction("Index", "QLNhanVien");//phan phia trc là trang muốn hướng đến , phần phía sau là thư mục chứa trang đó
                    }
                    else if (user1.IDQuyen == NVBanHang)
                    {
                        return RedirectToAction("Index", "HoaDon");
                    }
                    else if (user1.IDQuyen == NVship)
                    {
                        return RedirectToAction("IndexShip", "PhieuMua");
                    }
                    else if (user1.IDQuyen == NVCSKH)
                    {
                        return RedirectToAction("Index", "Comment");
                    }
                    else if (user1.IDQuyen == NVQuanKho)
                    {
                        return RedirectToAction("Index", "LichNhap");
                    }
                    else // nếu chưa phân quyền thì hiện giao diện lỗi 
                    {
                        return RedirectToAction("Loi", "DangNhap");
                    }

                }

                return View();

            }
        }
        
    }
}