﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TTCD1_TranMinhDuc_2210900014.Models;

namespace TTCD1_TranMinhDuc_2210900014.Controllers
{
    public class HomeController : Controller
    {
        private Tmd_2210900014_TTCDEntities db = new Tmd_2210900014_TTCDEntities();
        public ActionResult Index()
        {
            ViewBag.Title = "Trang chủ";
            return View(db.Tmd_SanPham.ToList());
        }

        public ActionResult Newslist()
        {
            ViewBag.Title = "Tin tức công nghệ";
            return View(db.Tmd_News.ToList());
        }

        public ActionResult DetailsNew(int id)
        {
            ViewBag.Title = "Tin tức";
            var detailsnew = db.Tmd_News.Find(id);
            if (detailsnew == null)
            {
                return HttpNotFound();
            }

            return View(detailsnew);
        }

        public ActionResult Contact()
        {
            ViewBag.Title = "Thông tin liên hệ";
            return View();
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Tmd_KhachHang _tmd_KhachHang)
        {
            var existingUser = db.Tmd_KhachHang.FirstOrDefault(u => u.TaiKhoan == _tmd_KhachHang.TaiKhoan);

            var existingEmail = db.Tmd_KhachHang.FirstOrDefault(u => u.Email == _tmd_KhachHang.Email);

            if (existingUser != null)
            {
                ModelState.AddModelError("TaiKhoan", "Tên đăng nhập đã tồn tại. Vui lòng chọn tên khác.");
            }

            if (existingEmail != null)
            {
                ModelState.AddModelError("Email", "Email đã tồn tại. Vui lòng sử dụng email khác.");
            }

            if (!ModelState.IsValid)
            {
                return View();
            }

            db.Tmd_KhachHang.Add(_tmd_KhachHang);
            db.SaveChanges();
            return RedirectToAction("Login");
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Tmd_KhachHang _tmd_KhachHang)
        {
            var user = db.Tmd_KhachHang.FirstOrDefault(u => u.TaiKhoan == _tmd_KhachHang.TaiKhoan && u.MatKhau == _tmd_KhachHang.MatKhau);

            if (user != null)
            {
                Session["UserID"] = user.MaKH.ToString();
                Session["Username"] = user.TaiKhoan.ToString();
                return RedirectToAction("Index");
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