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
    public class Tmd_KhachHangController : Controller
    {
        private Tmd_2210900014_TTCDEntities db = new Tmd_2210900014_TTCDEntities();

        // GET: Tmd_KhachHang
        public ActionResult Index()
        {
            return View(db.Tmd_KhachHang.ToList());
        }

        // GET: Tmd_KhachHang/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tmd_KhachHang tmd_KhachHang = db.Tmd_KhachHang.Find(id);
            if (tmd_KhachHang == null)
            {
                return HttpNotFound();
            }
            return View(tmd_KhachHang);
        }

        // GET: Tmd_KhachHang/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tmd_KhachHang/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaKH,HoTen,TaiKhoan,DienThoai,Email,GioiTinh,MatKhau,NgaySinh,TrangThai")] Tmd_KhachHang tmd_KhachHang)
        {
            if (ModelState.IsValid)
            {
                db.Tmd_KhachHang.Add(tmd_KhachHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tmd_KhachHang);
        }

        // GET: Tmd_KhachHang/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tmd_KhachHang tmd_KhachHang = db.Tmd_KhachHang.Find(id);
            if (tmd_KhachHang == null)
            {
                return HttpNotFound();
            }
            return View(tmd_KhachHang);
        }

        // POST: Tmd_KhachHang/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaKH,HoTen,TaiKhoan,DienThoai,Email,GioiTinh,MatKhau,NgaySinh,TrangThai")] Tmd_KhachHang tmd_KhachHang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tmd_KhachHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tmd_KhachHang);
        }

        // GET: Tmd_KhachHang/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tmd_KhachHang tmd_KhachHang = db.Tmd_KhachHang.Find(id);
            if (tmd_KhachHang == null)
            {
                return HttpNotFound();
            }
            return View(tmd_KhachHang);
        }

        // POST: Tmd_KhachHang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tmd_KhachHang tmd_KhachHang = db.Tmd_KhachHang.Find(id);
            db.Tmd_KhachHang.Remove(tmd_KhachHang);
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
