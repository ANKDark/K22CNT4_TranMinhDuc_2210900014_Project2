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
    public class Tmd_HoTroController : Controller
    {
        private Tmd_2210900014_TTCDEntities db = new Tmd_2210900014_TTCDEntities();

        // GET: Tmd_HoTro
        public ActionResult Index()
        {
            return View(db.Tmd_HoTro.ToList());
        }

        // GET: Tmd_HoTro/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tmd_HoTro tmd_HoTro = db.Tmd_HoTro.Find(id);
            if (tmd_HoTro == null)
            {
                return HttpNotFound();
            }
            return View(tmd_HoTro);
        }

        // GET: Tmd_HoTro/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tmd_HoTro/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaHoTro,DiaChiEmail,HoTen,TrangThai,TinNhan")] Tmd_HoTro tmd_HoTro)
        {
            if (ModelState.IsValid)
            {
                db.Tmd_HoTro.Add(tmd_HoTro);
                db.SaveChanges();

                // Thiết lập thông báo thành công
                TempData["SuccessMessage"] = "Đã gửi thành công!";

                return RedirectToAction("Index", "Home");
            }

            return View("/Home/Index"); // Trả về form nếu có lỗi
        }
        // GET: Tmd_HoTro/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tmd_HoTro tmd_HoTro = db.Tmd_HoTro.Find(id);
            if (tmd_HoTro == null)
            {
                return HttpNotFound();
            }
            return View(tmd_HoTro);
        }

        // POST: Tmd_HoTro/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaHoTro,DiaChiEmail,HoTen,TrangThai,TinNhan")] Tmd_HoTro tmd_HoTro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tmd_HoTro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tmd_HoTro);
        }

        // GET: Tmd_HoTro/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tmd_HoTro tmd_HoTro = db.Tmd_HoTro.Find(id);
            if (tmd_HoTro == null)
            {
                return HttpNotFound();
            }
            return View(tmd_HoTro);
        }

        // POST: Tmd_HoTro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tmd_HoTro tmd_HoTro = db.Tmd_HoTro.Find(id);
            db.Tmd_HoTro.Remove(tmd_HoTro);
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
