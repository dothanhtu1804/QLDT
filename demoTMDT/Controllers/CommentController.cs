using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using demoTMDT.Models;

namespace TestCMT.Controllers
{
    public class CommentController : Controller
    {
        DiDongPortalEntities2 data = new DiDongPortalEntities2();
        // GET: Comment
        public ActionResult Index()
        {
            return View(data.Comments.OrderByDescending(s => s.ID).ToList());
        }

        // GET: Comment/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Comment/Create
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

        // GET: Comment/Edit/5
        public ActionResult Edit(int id)
        {
            return View(data.Comments.Where(s => s.ID == id).FirstOrDefault());
        }

        // POST: Comment/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Comment cmt)
        {
            try
            {
                // TODO: Add update logic here
                data.Entry(cmt).State = System.Data.Entity.EntityState.Modified;
                data.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Comment/Delete/5
        public ActionResult Delete(int id)
        {
            return View(data.Comments.Where(s => s.ID == id).FirstOrDefault());
        }

        // POST: Comment/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Comment cmt)
        {
            try
            {
                // TODO: Add delete logic here
                cmt = data.Comments.Where(s => s.ID == id).FirstOrDefault();
                data.Comments.Remove(cmt);
                data.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }



        [ChildActionOnly]
        public ActionResult _ChildComment(int id)
        {
            var cmt = data.Comments.Where(s => s.Parent == id).ToList();
            return PartialView("_ChildComment", data);
        }

    }

}
