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
    public class Tmd_SanPhamController : Controller
    {
        private Tmd_2210900014_TTCDEntities db = new Tmd_2210900014_TTCDEntities();

        // GET: Tmd_SanPham
        public ActionResult Index()
        {
            var tmd_SanPham = db.Tmd_SanPham.Include(t => t.Tmd_NSX).ToList();

            foreach (var sanPham in tmd_SanPham)
            {
                if (sanPham.SoLuong == 0)
                {
                    sanPham.TinhTrang = false;
                    db.Entry(sanPham).State = EntityState.Modified;
                }
            }

            db.SaveChanges();

            return View(tmd_SanPham);
        }

        // GET: Tmd_SanPham/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tmd_SanPham tmd_SanPham = db.Tmd_SanPham.Find(id);
            if (tmd_SanPham == null)
            {
                return HttpNotFound();
            }
            return View(tmd_SanPham);
        }

        // GET: Tmd_SanPham/Create
        public ActionResult Create()
        {
            ViewBag.MaNSX = new SelectList(db.Tmd_NSX, "MaNSX", "TenNSX");
            return View();
        }

        // POST: Tmd_SanPham/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaSP,TenSP,SoLuong,NgayNhap,GiaBan,GiaNhap,Sale,SoLuongDaBan,TinhTrang,img1,img2,img3,MaNSX,GiaSale,Mota,LoaiSP")] Tmd_SanPham tmd_SanPham)
        {
            if (ModelState.IsValid)
            {
                db.Tmd_SanPham.Add(tmd_SanPham);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaNSX = new SelectList(db.Tmd_NSX, "MaNSX", "TenNSX", tmd_SanPham.MaNSX);
            return View(tmd_SanPham);
        }

        // GET: Tmd_SanPham/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tmd_SanPham tmd_SanPham = db.Tmd_SanPham.Find(id);
            if (tmd_SanPham == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaNSX = new SelectList(db.Tmd_NSX, "MaNSX", "TenNSX", tmd_SanPham.MaNSX);
            return View(tmd_SanPham);
        }

        // POST: Tmd_SanPham/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "MaSP,TenSP,SoLuong,NgayNhap,GiaBan,GiaNhap,Sale,SoLuongDaBan,TinhTrang,img1,img2,img3,MaNSX,GiaSale,Mota,LoaiSP")] Tmd_SanPham tmd_SanPham)
        {
            if (ModelState.IsValid)
            {
                if (tmd_SanPham.SoLuong == 0)
                {
                    tmd_SanPham.TinhTrang = false;
                }
                db.Entry(tmd_SanPham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaNSX = new SelectList(db.Tmd_NSX, "MaNSX", "TenNSX", tmd_SanPham.MaNSX);
            return View(tmd_SanPham);
        }

        // GET: Tmd_SanPham/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tmd_SanPham tmd_SanPham = db.Tmd_SanPham.Find(id);
            if (tmd_SanPham == null)
            {
                return HttpNotFound();
            }
            return View(tmd_SanPham);
        }

        // POST: Tmd_SanPham/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tmd_SanPham tmd_SanPham = db.Tmd_SanPham.Find(id);
            db.Tmd_SanPham.Remove(tmd_SanPham);
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
