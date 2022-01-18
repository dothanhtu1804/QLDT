using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace demoTMDT.Models
{
    public class CartItem
    {
        public DienThoai giohang { get; set; }
        public int _soluongdt { get; set; }
    }

    public class Cart
    {
        List<CartItem> item = new List<CartItem>();

        public IEnumerable<CartItem> Item
        {
            get { return item; }
        }

        public void Add(DienThoai _hang, int _quantity = 1)
        {
            var i = item.FirstOrDefault(s => s.giohang.IdDT == _hang.IdDT);
            if (i == null)
            {
                item.Add(new CartItem
                {
                    giohang = _hang,
                    _soluongdt = _quantity
                });
            }
            else
            {
                i._soluongdt += _quantity;
            }
        }

        public void Update(int id, int _quantity)
        {
            var i = item.Find(s => s.giohang.IdDT == id);
            if (i != null)
            {
                if (item.Find(s => s.giohang.SoLuong >= _quantity) != null)
                    i._soluongdt = _quantity;
                else i._soluongdt = 1;
                if (item.Find(s => s.giohang.SoLuong == 0) != null)
                    i._soluongdt = 0;
            }
        }

        public double sum()
        {
            var sum = item.Sum(s => s._soluongdt * 1);
            return sum;
        }

        public void Remove(int id)
        {
            item.RemoveAll(s => s.giohang.IdDT == id);
        }

        
        public int Total_money()
        {
            var total = item.Sum(s => s.giohang.Gia * s._soluongdt);
            return (int) total;
        }

        public void claer()
        {
            item.Clear();
        }

        public int Total ()
        {
            return Item.Sum(s => s._soluongdt);
        }
    }
}