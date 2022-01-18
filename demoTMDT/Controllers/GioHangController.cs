using demoTMDT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace demoTMDT.Controllers
{
    public class GioHangController : Controller
    {
        DiDongPortalEntities2 data = new DiDongPortalEntities2();

        public Cart GetDT()
        {
            Cart gio = Session["GioHang"] as Cart;
            if (gio == null || Session["GioHang"] == null)
            {
                gio = new Cart();
                Session["GioHang"] = gio;
            }
            return gio;
        }

        // GET: GioHang
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Addto(int id)
        {
            var gio = data.DienThoais.SingleOrDefault(s => s.IdDT == id);
            if (gio != null)
            {
                GetDT().Add(gio);
            }
            return RedirectToAction("Show", "GioHang");
        }

        public ActionResult Show()
        {
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("Show", "GioHang");
            }
            Cart gio = Session["GioHang"] as Cart;
            return View(gio);
        }

        public ActionResult Update_quantity(FormCollection form)
        {
            Cart gio = Session["GioHang"] as Cart;
            int id_DT = int.Parse(form["Id DT"]);
            int quantity = int.Parse(form["quantity"]);
            gio.Update(id_DT, quantity);
            return RedirectToAction("Show", "GioHang");
        }

        public PartialViewResult Bag ()
        {
            int total = 0;
            Cart gio = Session["GioHang"] as Cart; 
            if (gio != null)
            {
                total = gio.Total();
            }
            ViewBag.infocart = total;
            return PartialView("Bag");
        }

        public ActionResult TimKiem (string _name)
        {
            if (_name == null)
            {
                return View(data.HoaDons.ToList());
            }
            else
            {
                return View(data.HoaDons.Where(s => s.SĐT.Contains(_name)).ToList());
            }
        }

        public ActionResult Use_voucher(FormCollection form)
        {

            //vẫn đang lỗi chưa sử dụng dc

            Cart gio = Session["GioHang"] as Cart;
            PhieuMua mua = new PhieuMua();
            mua.KhuyenMai = form["KM"];
            //string maKM = form["KM"];
            foreach (var voucher in data.KhuyenMais.Where(s => s.MaKM == mua.KhuyenMai))
            {
                DateTime ngayketthuc = Convert.ToDateTime(voucher.NgayKetThuc);
                DateTime ngayhientai = DateTime.Now;
                DateTime ngaybatdau = Convert.ToDateTime(voucher.NgayBatDau);

                TimeSpan timespan = ngaybatdau - ngayhientai;
                int TongNgay = timespan.Days;

                TimeSpan Time = ngayketthuc - ngayhientai;
                int TongSoNgay = Time.Days;

                if (TongNgay < 0)
                {
                    return Content("<script language='javascript' type='text/javascript'>alert     ('Voucher chưa đến ngày sử dụng!');</script>");
                }


                if (TongSoNgay <= 0)
                {
                    return Content("<script language='javascript' type='text/javascript'>alert     ('Voucher đã hết hạn!');</script>");
                }
                foreach (var item in gio.Item)
                {
                    if (mua.KhuyenMai.Contains("KM"))
                    {
                        if (voucher.ChiTiet.Contains("10%"))
                        {
                            item.giohang.Gia = item.giohang.Gia - (item.giohang.Gia * 10 / 100);
                        }
                    }
                }
                HoaDon Detail = new HoaDon();
                foreach (var item in gio.Item)
                {
                    Detail.Gia = item._soluongdt * item.giohang.Gia;
                }


            }
            return RedirectToAction("Show", "GioHang");
        }

        public ActionResult Remove(int id)
        {
            Cart gio = Session["GioHang"] as Cart;
            gio.Remove(id);
            return RedirectToAction("Show", "GioHang");
        }

        public ActionResult HoaDon()
        {

            int soHD = 0;
            int n = 0;
            HoaDon HD = new HoaDon();
            foreach (var hd in data.HoaDons)
            {
                n += 1;
            }

            //return View(data.HoaDons.Take(1).OrderByDescending(s=>s.IdHoaDon));
            return View(data.HoaDons.OrderByDescending(s => s.IdHoaDon).Take(1));
        }

        public ActionResult MuaHang(FormCollection form)
        {

            Cart gio = Session["GioHang"] as Cart;
            PhieuMua mua = new PhieuMua();
            mua.TenKH = form["TenKH"];
            mua.NgayMua = DateTime.Now;
            mua.Email = form["email"];
            mua.SĐT = form["sđt"];
            mua.DiaChi = form["Diachi"];
            mua.KhuyenMai = form["KM"];
            mua.Mau = form["MauSac"];
            mua.HThuc = form["hinhthuc"];
            string hinhthucmua = form["hinhthuc"];
            if (hinhthucmua != null)
            {
                mua.TinhTrang = "Đang chờ xác nhận";
            }


            if (mua.TenKH == "" || mua.DiaChi == "" || mua.Email == "" || mua.SĐT == "")
            {
                return RedirectToAction("Show", "GioHang");
                //return Content("<script language='javascript' type='text/javascript'>alert     ('Vui lòng điền tên khách hàng!');</script>");
            }

            //return để báo lỗi
            //return Content("<script language='javascript' type='text/javascript'>alert     ('');</script>");


            /*
            if (mua.DiaChi == "")
            {
                return Content("<script language='javascript' type='text/javascript'>alert     ('Vui lòng điền địa chỉ');</script>");
            }
            if (mua.SĐT == "")
            {
                return Content("<script language='javascript' type='text/javascript'>alert     ('Vui lòng điền địa chỉ');</script>");
            }*/


            foreach (var voucher in data.KhuyenMais.Where(s => s.MaKM == mua.KhuyenMai))
            {
                DateTime ngayketthuc = Convert.ToDateTime(voucher.NgayKetThuc);
                DateTime ngayhientai = DateTime.Now;
                DateTime ngaybatdau = Convert.ToDateTime(voucher.NgayBatDau);

                TimeSpan timespan = ngaybatdau - ngayhientai;
                int TongNgay = timespan.Days;

                TimeSpan Time = ngayketthuc - ngayhientai;
                int TongSoNgay = Time.Days;

                if (TongNgay > 0)
                {
                    return Content("<script language='javascript' type='text/javascript'>alert     ('Voucher chưa đến ngày sử dụng!');</script>");
                }


                if (TongSoNgay <= 0)
                {
                    return Content("<script language='javascript' type='text/javascript'>alert     ('Voucher đã hết hạn!');</script>");
                }
                int tongsl = 0;
                foreach (var item in gio.Item)
                {
                    tongsl += 1;



                    if (tongsl >= 2)
                    {
                        return Content("<script language='javascript' type='text/javascript'>alert     ('Khuyến Mãi chỉ áp dụng cho 1 sản phẩm');</script>");
                    }


                    string maKM = Convert.ToString(mua.KhuyenMai);


                    foreach (var p in data.KhuyenMais.Where(s => s.MaKM == mua.KhuyenMai))
                    {
                        string maKm = p.MaKM;

                        if (String.Compare(maKM, mua.KhuyenMai) == 0 && p.SoLuongConLai == 0)
                        {
                            return Content("<script language='javascript' type='text/javascript'>alert     ('Mã Khuyến Mãi đã hết lượt sử dụng!');</script>");
                        }

                    }


                    if (mua.KhuyenMai.Contains("KM")) //km theo giá 
                    {



                        if (voucher.ChiTiet.Contains("20%") && item.giohang.Gia >= 20000000)
                        {
                            int giagiam = 0;
                            giagiam = (int)item.giohang.Gia * 20 / 100;


                            item.giohang.Gia = item.giohang.Gia - giagiam;
                        }



                        if (voucher.ChiTiet.Contains("10%") && item.giohang.Gia >= 15000000 && item.giohang.Gia < 20000000)
                        {
                            int giagiam = 0;
                            giagiam = (int)item.giohang.Gia * 10 / 100;


                            item.giohang.Gia = item.giohang.Gia - giagiam;
                        }


                        if (voucher.ChiTiet.Contains("5%") && item.giohang.Gia >= 10000000 && item.giohang.Gia < 15000000)
                        {
                            int giagiam = 0;
                            giagiam = (int)item.giohang.Gia * 5 / 100;


                            item.giohang.Gia = item.giohang.Gia - giagiam;
                        }

                    }



                    if (mua.KhuyenMai.Contains("OPPO")) //km theo oppo
                    {
                        if (hinhthucmua == "Trực Tiếp" && item.giohang.TenDT.Contains("OPPO"))
                        {
                            item.giohang.Gia = item.giohang.Gia - 1000000;
                        }
                    }







                    //Update SL Mã KM
                    foreach (var p in data.KhuyenMais.Where(s => s.MaKM == mua.KhuyenMai))
                    {
                        string maKm = p.MaKM;

                        if (String.Compare(maKM, mua.KhuyenMai) == 0)
                        {
                            var update_soluong = p.SoLuongConLai - 1;
                            p.SoLuongConLai = update_soluong;
                        }

                    }




                }


            }
            data.PhieuMuas.Add(mua);
            foreach (var item in gio.Item)
            {
                int tongDT = 0;
                tongDT = tongDT + 1;
                if (tongDT == 0)
                {
                    return Content("<script language='javascript' type='text/javascript'>alert     ('Không có điện thoại trong giỏ hàng!');</script>");
                }
                HoaDon Detail = new HoaDon();
                Detail.IdPM = mua.IdPM;
                Detail.IdDT = item.giohang.IdDT;
                Detail.TenDT = item.giohang.TenDT;
                Detail.SĐT = mua.SĐT;
                Detail.DiaChi = mua.DiaChi;
                Detail.Email = mua.Email;
                Detail.TenKH = mua.TenKH;
                
                Detail.SoLuong = item._soluongdt;
                Detail.Gia = item._soluongdt * item.giohang.Gia;
                data.HoaDons.Add(Detail);

                

                    //Update SL ĐT còn lại
                    foreach (var dt in data.DienThoais.Where(s => s.IdDT == Detail.IdDT))
                {
                    var update_soluong = dt.SoLuong - item._soluongdt;
                    dt.SoLuong = update_soluong;
                }




                foreach (var p in data.DienThoais.Where(s => s.IdDT == Detail.IdDT))
                {
                    if (p.SoLuong < item._soluongdt)
                    {

                        return Content("<script language='javascript' type='text/javascript'>alert     ('Không đủ số lượng theo yêu cầu !');</script>");
                    }
                }


            }



            data.SaveChanges();
            gio.claer();
            return RedirectToAction("HoaDon", "GioHang");

        }


    }
}