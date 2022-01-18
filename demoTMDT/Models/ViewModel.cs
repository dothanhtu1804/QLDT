using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace demoTMDT.Models
{
    public class ViewModel
    {
       public string TenDT { get; set; }
        public int gianhap { get; set; }
        public string Hinhanh { get; set; }
        public string giaban { get; set; }
        [System.ComponentModel.DataAnnotations.Key]
       public DienThoai dienthoai { get; set; }
        public HoaDon hoadon { get; set; }
        public PhieuMua phieumua { get; set; }
        public IEnumerable<DienThoai> dsdt { get; set; }
        public string IdDT { get; set; }
        public int? TongSoLuong { get; set; }
        public int? TongTien { get; set; }
        public int? TongTiennhap { get; set; }
        public int? tienloi { get; set; }

    }
}