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
    public class Tmd_QuantriController : Controller
    {
        private Tmd_2210900014_TTCDEntities db = new Tmd_2210900014_TTCDEntities();

        // GET: Tmd_Quantri
        public ActionResult Index()
        {
            return View(db.Tmd_Quantri.ToList());
        }

        // GET: Tmd_Quantri/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tmd_Quantri tmd_Quantri = db.Tmd_Quantri.Find(id);
            if (tmd_Quantri == null)
            {
                return HttpNotFound();
            }
            return View(tmd_Quantri);
        }

        // GET: Tmd_Quantri/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tmd_Quantri/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaAdmin,HotenAdmin,MatkhauAdmin,TrangThai,Taikhoan")] Tmd_Quantri tmd_Quantri)
        {
            if (ModelState.IsValid)
            {
                db.Tmd_Quantri.Add(tmd_Quantri);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tmd_Quantri);
        }

        // GET: Tmd_Quantri/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tmd_Quantri tmd_Quantri = db.Tmd_Quantri.Find(id);
            if (tmd_Quantri == null)
            {
                return HttpNotFound();
            }
            return View(tmd_Quantri);
        }

        // POST: Tmd_Quantri/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaAdmin,HotenAdmin,MatkhauAdmin,TrangThai,Taikhoan")] Tmd_Quantri tmd_Quantri)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tmd_Quantri).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tmd_Quantri);
        }

        // GET: Tmd_Quantri/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tmd_Quantri tmd_Quantri = db.Tmd_Quantri.Find(id);
            if (tmd_Quantri == null)
            {
                return HttpNotFound();
            }
            return View(tmd_Quantri);
        }

        // POST: Tmd_Quantri/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tmd_Quantri tmd_Quantri = db.Tmd_Quantri.Find(id);
            db.Tmd_Quantri.Remove(tmd_Quantri);
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
