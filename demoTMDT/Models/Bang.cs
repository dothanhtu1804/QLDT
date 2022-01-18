using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace demoTMDT.Models
{
   
    public class Bang
    {
        DiDongPortalEntities2 data = new DiDongPortalEntities2();

        public List<Comment> listcmt()
        {
            
            return data.Comments.ToList();
        }
        public List<LichNhap> listLich()
        {

            return data.LichNhaps.ToList();
        }

        List<Thongke> item = new List<Thongke>();

        public IEnumerable<Thongke> Item
        {
            get { return item; }
        }
        public int sumnhap()
        {

            var sum = Item.Sum(s => s.tknhap.ThanhTien + s.tknhap.ThanhTien);
            return (int)sum;
        }
       
    }

    public class Thongke
    {
        public LichNhap tknhap { get; set; }
        public HoaDon tkBan { get; set; }
    }
}

   

    

   
