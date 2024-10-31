using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TTCD1_TranMinhDuc_2210900014.Models;

namespace TTCD1_TranMinhDuc_2210900014.Controllers
{
    public class CartsController : Controller
    {
        private Tmd_2210900014_TTCDEntities db = new Tmd_2210900014_TTCDEntities();

        public ActionResult Cart()
        {
            ViewBag.Title = "Giỏ hàng";
            var cart = Session["Cart"] as List<Giohang> ?? new List<Giohang>();
            ViewBag.CartCount = cart.Sum(p => p.SoLuong);
            return View(cart);
        }

        [HttpPost]
        public ActionResult AddToCart(int MaSP, int SoLuong)
        {
            var product = db.Tmd_SanPham.FirstOrDefault(p => p.MaSP == MaSP);
            if (product == null)
            {
                return HttpNotFound();
            }

            var cart = Session["Cart"] as List<Giohang> ?? new List<Giohang>();

            var existingProduct = cart.FirstOrDefault(p => p.MaSP == MaSP);

            if (existingProduct != null)
            {
                existingProduct.SoLuong += SoLuong;
            }
            else
            {
                var newProduct = new Giohang
                {
                    MaSP = MaSP,
                    TenSP = product.TenSP,
                    GiaBan = product.GiaBan,
                    SoLuong = SoLuong,
                    img = product.img1,
                    TongHD = SoLuong * product.GiaBan
                };
                cart.Add(newProduct);
            }

            Session["Cart"] = cart;

            return RedirectToAction("Cart");
        }

        [HttpPost]
        public ActionResult RemoveFromCart(int MaSP)
        {
            var cart = Session["Cart"] as List<Giohang>;
            if (cart != null)
            {
                var item = cart.FirstOrDefault(p => p.MaSP == MaSP);
                if (item != null)
                {
                    cart.Remove(item);
                    Session["Cart"] = cart;
                }
            }

            return RedirectToAction("Cart");
        }

        [HttpPost]
        public ActionResult UpdateQuantity(int MaSP, string action)
        {
            var cart = Session["Cart"] as List<Giohang>;
            if (cart != null)
            {
                var item = cart.FirstOrDefault(p => p.MaSP == MaSP);
                if (item != null)
                {
                    if (action == "increase")
                    {
                        item.SoLuong++;
                    }
                    else if (action == "decrease" && item.SoLuong > 1)
                    {
                        item.SoLuong--;
                    }
                }
            }

            return RedirectToAction("Cart");
        }
    }
}
