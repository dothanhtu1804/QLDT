using demoTMDT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace demoTMDT.Controllers
{
    public class ListDTController : Controller
    {
        DiDongPortalEntities2 data = new DiDongPortalEntities2();
        // GET: ListDT
        public ActionResult Index()
        {
            return View(data.DienThoais.Take(4).OrderByDescending(x => x.IdDT).ToList());
        }

        public ActionResult CT_SP(int id)
        {
            var bang = new Bang();
            
            ViewBag.cmt = bang.listcmt();
            return View(data.DienThoais.Where(s=>s.IdDT == id).FirstOrDefault());
        }

        public ActionResult DS_DT ( string Hang)
        {

            if ( Hang == null)
            {
                return View(data.DienThoais.ToList());
            }
            
            else  
            {
                var list = data.DienThoais.OrderByDescending(x => x.TenDT)
                    .Where(x => x.idHang == Hang);
                return View(list);
            }           
        }

        public ActionResult TimKiem (string _name)
        {
            if (_name == null)
            {
                return View(data.DienThoais.ToList());
            }
            else 
            {
                return View(data.DienThoais.Where(s => s.TenDT.Contains(_name)).ToList());
            }
        }

        public ActionResult Index2()
        {
            return View(data.Comments.OrderByDescending(s => s.ID).ToList());
        }

        public ActionResult Create()
        {

            Comment cmt = new Comment();
            return View(cmt);
        }

        // POST: Comment/Create
        [HttpPost]
        public ActionResult Create(Comment cmt)
        {
            data.Comments.Add(cmt);
            data.SaveChanges();
            return RedirectToAction("Index");
        }

        [ChildActionOnly]
        public ActionResult _ChildComment(int id)
        {
            var cmt = data.Comments.Where(s => s.Parent == id).ToList();
            return PartialView("_ChildComment", cmt);
        }
    }
}