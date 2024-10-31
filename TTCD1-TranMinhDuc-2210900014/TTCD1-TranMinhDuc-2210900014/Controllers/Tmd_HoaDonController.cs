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
    public class Tmd_HoaDonController : Controller
    {
        private Tmd_2210900014_TTCDEntities db = new Tmd_2210900014_TTCDEntities();

        // GET: Tmd_HoaDon
        public ActionResult Index()
        {
            var tmd_HoaDon = db.Tmd_HoaDon.Include(t => t.Tmd_KhachHang).Include(t => t.Tmd_SanPham);
            return View(tmd_HoaDon.ToList());
        }

        // GET: Tmd_HoaDon/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tmd_HoaDon tmd_HoaDon = db.Tmd_HoaDon.Find(id);
            if (tmd_HoaDon == null)
            {
                return HttpNotFound();
            }
            return View(tmd_HoaDon);
        }

        // GET: Tmd_HoaDon/Create
        public ActionResult Create()
        {
            ViewBag.MaKH = new SelectList(db.Tmd_KhachHang, "MaKH", "HoTen");
            ViewBag.MaSP = new SelectList(db.Tmd_SanPham, "MaSP", "TenSP");
            return View();
        }

        // POST: Tmd_HoaDon/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaHD,DiaChiNN,DienThoaiNN,NgayDat,NgayGiao,TrangThai,MaKH,MaSP,SoLuong,Gia")] Tmd_HoaDon tmd_HoaDon)
        {
            if (ModelState.IsValid)
            {
                db.Tmd_HoaDon.Add(tmd_HoaDon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaKH = new SelectList(db.Tmd_KhachHang, "MaKH", "HoTen", tmd_HoaDon.MaKH);
            ViewBag.MaSP = new SelectList(db.Tmd_SanPham, "MaSP", "TenSP", tmd_HoaDon.MaSP);
            return View(tmd_HoaDon);
        }

        // GET: Tmd_HoaDon/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tmd_HoaDon tmd_HoaDon = db.Tmd_HoaDon.Find(id);
            if (tmd_HoaDon == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaKH = new SelectList(db.Tmd_KhachHang, "MaKH", "HoTen", tmd_HoaDon.MaKH);
            ViewBag.MaSP = new SelectList(db.Tmd_SanPham, "MaSP", "TenSP", tmd_HoaDon.MaSP);
            return View(tmd_HoaDon);
        }

        // POST: Tmd_HoaDon/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaHD,DiaChiNN,DienThoaiNN,NgayDat,NgayGiao,TrangThai,MaKH,MaSP,SoLuong,Gia")] Tmd_HoaDon tmd_HoaDon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tmd_HoaDon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaKH = new SelectList(db.Tmd_KhachHang, "MaKH", "HoTen", tmd_HoaDon.MaKH);
            ViewBag.MaSP = new SelectList(db.Tmd_SanPham, "MaSP", "TenSP", tmd_HoaDon.MaSP);
            return View(tmd_HoaDon);
        }

        // GET: Tmd_HoaDon/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tmd_HoaDon tmd_HoaDon = db.Tmd_HoaDon.Find(id);
            if (tmd_HoaDon == null)
            {
                return HttpNotFound();
            }
            return View(tmd_HoaDon);
        }

        // POST: Tmd_HoaDon/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tmd_HoaDon tmd_HoaDon = db.Tmd_HoaDon.Find(id);
            db.Tmd_HoaDon.Remove(tmd_HoaDon);
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
