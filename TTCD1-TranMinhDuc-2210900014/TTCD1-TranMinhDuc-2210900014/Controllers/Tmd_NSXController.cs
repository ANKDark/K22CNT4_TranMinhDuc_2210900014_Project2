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
    public class Tmd_NSXController : Controller
    {
        private Tmd_2210900014_TTCDEntities db = new Tmd_2210900014_TTCDEntities();

        // GET: Tmd_NSX
        public ActionResult Index()
        {
            return View(db.Tmd_NSX.ToList());
        }

        // GET: Tmd_NSX/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tmd_NSX tmd_NSX = db.Tmd_NSX.Find(id);
            if (tmd_NSX == null)
            {
                return HttpNotFound();
            }
            return View(tmd_NSX);
        }

        // GET: Tmd_NSX/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tmd_NSX/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaNSX,TenNSX")] Tmd_NSX tmd_NSX)
        {
            if (ModelState.IsValid)
            {
                db.Tmd_NSX.Add(tmd_NSX);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tmd_NSX);
        }

        // GET: Tmd_NSX/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tmd_NSX tmd_NSX = db.Tmd_NSX.Find(id);
            if (tmd_NSX == null)
            {
                return HttpNotFound();
            }
            return View(tmd_NSX);
        }

        // POST: Tmd_NSX/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaNSX,TenNSX")] Tmd_NSX tmd_NSX)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tmd_NSX).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tmd_NSX);
        }

        // GET: Tmd_NSX/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tmd_NSX tmd_NSX = db.Tmd_NSX.Find(id);
            if (tmd_NSX == null)
            {
                return HttpNotFound();
            }
            return View(tmd_NSX);
        }

        // POST: Tmd_NSX/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Tmd_NSX tmd_NSX = db.Tmd_NSX.Find(id);
            db.Tmd_NSX.Remove(tmd_NSX);
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
