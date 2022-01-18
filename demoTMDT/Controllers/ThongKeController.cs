using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using demoTMDT.Models;

namespace demoTMDT.Controllers
{
    public class ThongKeController : Controller
    {
        DiDongPortalEntities2 data = new DiDongPortalEntities2();
        // GET: ThongKe
        public ActionResult BCnhaphang()
        {
            
            return View(data.LichNhaps.ToList());
        }

        public PartialViewResult solieu()
        {
      
           ViewBag.bang = data.LichNhaps.Sum(x => x.ThanhTien);
            return PartialView("solieu");
        }

        public ActionResult BCbanhang()
        {
            List<DienThoai> dsdt = data.DienThoais.ToList();
            List<HoaDon> dshd = data.HoaDons.ToList();

            var query = from hd in dshd
                        join
             dt in dsdt on hd.IdDT equals dt.IdDT into tbl
                        group hd by new
                        {
                            IdDT = Convert.ToString(hd.IdDT),
                            TenDT = hd.TenDT,
                            Hinhanh = hd.DienThoai.hinh1,
                        }
                        into gr
                        orderby gr.Sum(s => s.SoLuong) descending
                        select new ViewModel
                        {
                            IdDT = gr.Key.IdDT,
                            TenDT = gr.Key.TenDT,
                            Hinhanh = gr.Key.Hinhanh,
                            TongSoLuong = gr.Sum(s => s.SoLuong),
                            TongTien = gr.Sum(s => s.Gia)
                        };
            return View(query.ToList());
        }

        public PartialViewResult Tongtienban()
        {
            List<DienThoai> dsdt = data.DienThoais.ToList();
            List<HoaDon> dshd = data.HoaDons.ToList();

            var query = from hd in dshd
                        join
             dt in dsdt on hd.IdDT equals dt.IdDT into tbl
                        group hd by new
                        {
                            IdDT = Convert.ToString(hd.IdDT),
                            TenDT = hd.TenDT,
                            Hinhanh = hd.DienThoai.hinh1,
                        }
                        into gr
                        orderby gr.Sum(s => s.SoLuong) descending
                        select new ViewModel
                        {
                            IdDT = gr.Key.IdDT,
                            TenDT = gr.Key.TenDT,
                            Hinhanh = gr.Key.Hinhanh,
                            TongSoLuong = gr.Sum(s => s.SoLuong),
                            TongTien = gr.Sum(s => s.Gia)
                        };
           
            ViewBag.tien = query.Sum(s => s.TongTien);
            return PartialView("Tongtienban");
        }

        public ActionResult BCDoanhThu()
        {
            List<DienThoai> dsdt = data.DienThoais.ToList();
            List<HoaDon> dshd = data.HoaDons.ToList();

            var query = from hd in dshd
                        join
             dt in dsdt on hd.IdDT equals dt.IdDT into tbl
                        group hd by new
                        {
                            IdDT = Convert.ToString(hd.IdDT),
                            TenDT = hd.TenDT,
                            Hinhanh = hd.DienThoai.hinh1,
                            Gianhap = hd.DienThoai.LichNhap.DonGia,
                            Giaban = hd.DienThoai.Gia,
                        }
                        into gr
                        orderby gr.Sum(s => s.SoLuong) descending
                        select new ViewModel
                        {
                            IdDT = gr.Key.IdDT,
                            TenDT = gr.Key.TenDT,
                            Hinhanh = gr.Key.Hinhanh,
                            gianhap = Convert.ToInt32(gr.Key.Gianhap),
                            giaban = Convert.ToString(gr.Key.Giaban),
                            TongSoLuong = gr.Sum(s => s.SoLuong),
                            TongTiennhap = gr.Key.Gianhap * gr.Sum(s => s.SoLuong),
                            TongTien = gr.Sum(s => s.Gia),
                            tienloi = gr.Sum(s => s.Gia) - (gr.Key.Gianhap * gr.Sum(s => s.SoLuong))
                        };
            return View(query.ToList());
        }

        public PartialViewResult DoanhThu()
        {
            List<DienThoai> dsdt = data.DienThoais.ToList();
            List<HoaDon> dshd = data.HoaDons.ToList();

            var query = from hd in dshd
                        join
             dt in dsdt on hd.IdDT equals dt.IdDT into tbl
                        group hd by new
                        {
                            IdDT = Convert.ToString(hd.IdDT),
                            TenDT = hd.TenDT,
                            Hinhanh = hd.DienThoai.hinh1,
                            Gianhap = hd.DienThoai.LichNhap.DonGia,
                        }
                        into gr
                        orderby gr.Sum(s => s.SoLuong) descending
                        select new ViewModel
                        {
                            IdDT = gr.Key.IdDT,
                            TenDT = gr.Key.TenDT,
                            Hinhanh = gr.Key.Hinhanh,
                            gianhap = Convert.ToInt32(gr.Key.Gianhap),
                           
                            TongSoLuong = gr.Sum(s => s.SoLuong),
                            TongTiennhap = gr.Key.Gianhap * gr.Sum(s=>s.SoLuong),
                            TongTien = gr.Sum(s => s.Gia),
                            tienloi = gr.Sum(s=>s.Gia) - (gr.Key.Gianhap * gr.Sum(s => s.SoLuong)),
                            
                        };
          
            ViewBag.dthu = query.Sum(x => x.tienloi);
            return PartialView("DoanhThu");
        }
    }
}