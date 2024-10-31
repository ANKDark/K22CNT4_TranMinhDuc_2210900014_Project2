using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TTCD1_TranMinhDuc_2210900014.Models;

namespace TTCD1_TranMinhDuc_2210900014.Controllers
{
    public class CheckoutController : Controller
    {
        private Tmd_2210900014_TTCDEntities db = new Tmd_2210900014_TTCDEntities();

        // GET: Checkout
        public ActionResult Thongtin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Xacnhan(Tmd_HoaDon model)
        {
            if (ModelState.IsValid)
            {
                var cart = Session["Cart"] as List<Giohang>;
                if (cart != null && cart.Count > 0)
                {
                    var maKH = Session["UserID"] as string;

                    int id;
                    if (int.TryParse(maKH, out id))
                    {
                        var khachHang = db.Tmd_KhachHang.Find(id);
                        if (khachHang != null)
                        {
                            model.MaKH = khachHang.MaKH;
                            model.DienThoaiNN = khachHang.DienThoai;
                            model.DiaChiNN = Request.Form["DiaChi"];
                        }
                    }

                    foreach (var item in cart)
                    {
                        
                        var hoadon = new Tmd_HoaDon
                        {
                            DiaChiNN = model.DiaChiNN,
                            DienThoaiNN = model.DienThoaiNN,
                            NgayDat = DateTime.Now,
                            NgayGiao = model.NgayGiao,
                            TrangThai = false,
                            MaKH = model.MaKH,
                            MaSP = item.MaSP,
                            SoLuong = item.SoLuong,
                            Gia = item.GiaBan
                        };

                        db.Tmd_HoaDon.Add(hoadon);

                        var sanPham = db.Tmd_SanPham.Find(item.MaSP);
                        if (sanPham != null)
                        {
                            sanPham.SoLuong -= item.SoLuong; 
                                                 
                            if (sanPham.SoLuong < 0)
                            {
                                ModelState.AddModelError("", "Số lượng sản phẩm không đủ để đặt hàng.");
                                return View("Thongtin", model);
                            }
                        }
                    }

                    db.SaveChanges();

                    Session["Cart"] = new List<Giohang>();
                    return RedirectToAction("XacnhanThanhcong");
                }
                else
                {
                    ModelState.AddModelError("", "Giỏ hàng của bạn đang trống.");
                }
            }

            return View("Thongtin", model);
        }

        public ActionResult XacnhanThanhcong()
        {
            return View();
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
