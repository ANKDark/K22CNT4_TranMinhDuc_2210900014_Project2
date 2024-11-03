using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TTCD1_TranMinhDuc_2210900014.Models;

namespace TTCD1_TranMinhDuc_2210900014.Controllers
{
    public class ProductsController : Controller
    {
        private Tmd_2210900014_TTCDEntities db = new Tmd_2210900014_TTCDEntities();

        public ActionResult ByCategory(string category)
        {
            if (string.IsNullOrEmpty(category))
            {
                return View(new List<Tmd_SanPham>());
            }

            var products = db.Tmd_SanPham.Where(p => p.LoaiSP.Equals(category)).ToList();

            return View("Index", products);
        }
        public ActionResult Index(string category = null)
        {
            ViewBag.Title = "Loại sản phẩm";
            if (!string.IsNullOrEmpty(category))
            {
                var products = db.Tmd_SanPham.Where(p => p.LoaiSP.Equals(category)).ToList();
                return View(products);
            }

            var allProducts = db.Tmd_SanPham.ToList();
            return View(allProducts);
        }

        public ActionResult Search(string searchQuery)
        {
            ViewBag.Title = "Tìm kiếm";
            if (string.IsNullOrEmpty(searchQuery))
            {
                return View(new List<Tmd_SanPham>());
            }

            var result = db.Tmd_SanPham.Where(p => p.TenSP.Contains(searchQuery) || p.MaSP.ToString().Contains(searchQuery)).ToList();


            return View(result);
        }

        public ActionResult Details(int id)
        {
            ViewBag.Title = "Thông tin chi tiết";
            var product = db.Tmd_SanPham.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }

            return View(product);
        }
    }
}
