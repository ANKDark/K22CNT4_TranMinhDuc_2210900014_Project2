using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TTCD1_TranMinhDuc_2210900014.Models;
using System.Data.Entity;

namespace TTCD1_TranMinhDuc_2210900014.Controllers
{
    public class HomeAdminController : Controller
    {
        private Tmd_2210900014_TTCDEntities db = new Tmd_2210900014_TTCDEntities();
        // GET: HomeAdmin
        public ActionResult DashBoard()
        {
            var tmd_SanPham = db.Tmd_SanPham.Include(t => t.Tmd_NSX).ToList();
            var tmd_KhachHang = db.Tmd_KhachHang.ToList();
            var tmd_HoaDon = db.Tmd_HoaDon.ToList();
            var tmd_NSX = db.Tmd_NSX.ToList();
            var tmd_QuanTri = db.Tmd_Quantri.ToList();

            var viewModel = new DashboardViewModel
            {
                SanPhams = tmd_SanPham,
                KhachHangs = tmd_KhachHang,
                HoaDons = tmd_HoaDon,
                NhaSanXuats = tmd_NSX,
                QuanTris = tmd_QuanTri
            };

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Tmd_Quantri _tmd_QuanTri)
        {
            var admin = db.Tmd_Quantri.FirstOrDefault(u => u.Taikhoan == _tmd_QuanTri.Taikhoan && u.MatkhauAdmin == _tmd_QuanTri.MatkhauAdmin);

            if (admin != null)
            {
                Session["AdminID"] = admin.MaAdmin.ToString();
                Session["AdminName"] = admin.Taikhoan.ToString();
                return RedirectToAction("DashBoard");
            }
            else
            {
                ViewBag.Message = "Thông tin xác thực không hợp lệ!";
                return View();
            }
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }

    }
}