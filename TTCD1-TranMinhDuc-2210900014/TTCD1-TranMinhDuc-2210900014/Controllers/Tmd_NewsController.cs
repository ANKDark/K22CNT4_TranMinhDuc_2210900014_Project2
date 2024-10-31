using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TTCD1_TranMinhDuc_2210900014.Models;

namespace TTCD1_TranMinhDuc_2210900014.Controllers
{
    public class Tmd_NewsController : Controller
    {
        private Tmd_2210900014_TTCDEntities db = new Tmd_2210900014_TTCDEntities();

        // GET: Tmd_News
        public ActionResult Index()
        {
            return View(db.Tmd_News.ToList());
        }

        // GET: Tmd_News/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tmd_News tmd_News = db.Tmd_News.Find(id);
            if (tmd_News == null)
            {
                return HttpNotFound();
            }
            return View(tmd_News);
        }

        // GET: Tmd_News/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tmd_News/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaNew,TitleNew,Mota1,Mota2,Anh")] Tmd_News tmd_News)
        {
            if (ModelState.IsValid)
            {
                db.Tmd_News.Add(tmd_News);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tmd_News);
        }

        // GET: Tmd_News/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tmd_News tmd_News = db.Tmd_News.Find(id);
            if (tmd_News == null)
            {
                return HttpNotFound();
            }
            return View(tmd_News);
        }

        // POST: Tmd_News/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaNew,TitleNew,Mota1,Mota2,Anh")] Tmd_News tmd_News)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tmd_News).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tmd_News);
        }

        // GET: Tmd_News/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tmd_News tmd_News = db.Tmd_News.Find(id);
            if (tmd_News == null)
            {
                return HttpNotFound();
            }
            return View(tmd_News);
        }

        // POST: Tmd_News/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tmd_News tmd_News = db.Tmd_News.Find(id);
            db.Tmd_News.Remove(tmd_News);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
