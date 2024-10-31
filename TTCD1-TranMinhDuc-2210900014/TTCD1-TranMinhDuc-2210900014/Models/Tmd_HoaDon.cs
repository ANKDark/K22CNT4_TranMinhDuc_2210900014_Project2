using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TTCD1_TranMinhDuc_2210900014.Models
{
    public partial class Tmd_HoaDon
    {
        public int MaHD { get; set; }

        [Required(ErrorMessage = "Địa chỉ nhận hàng là bắt buộc.")]
        [StringLength(200, ErrorMessage = "Địa chỉ nhận hàng không được vượt quá 200 ký tự.")]
        public string DiaChiNN { get; set; }

        [Required(ErrorMessage = "Điện thoại nhận hàng là bắt buộc.")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Số điện thoại không hợp lệ. Phải có 10 chữ số.")]
        public Nullable<int> DienThoaiNN { get; set; }

        [Required(ErrorMessage = "Ngày đặt là bắt buộc.")]
        public Nullable<System.DateTime> NgayDat { get; set; }

        public Nullable<System.DateTime> NgayGiao { get; set; }

        public Nullable<bool> TrangThai { get; set; }

        [Required(ErrorMessage = "Mã khách hàng là bắt buộc.")]
        public Nullable<int> MaKH { get; set; }

        [Required(ErrorMessage = "Mã sản phẩm là bắt buộc.")]
        public Nullable<int> MaSP { get; set; }

        [Required(ErrorMessage = "Số lượng là bắt buộc.")]
        [Range(1, int.MaxValue, ErrorMessage = "Số lượng phải lớn hơn 0.")]
        public Nullable<int> SoLuong { get; set; }

        [Required(ErrorMessage = "Giá là bắt buộc.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Giá phải lớn hơn 0.")]
        public Nullable<decimal> Gia { get; set; }

        public virtual Tmd_KhachHang Tmd_KhachHang { get; set; }
        public virtual Tmd_SanPham Tmd_SanPham { get; set; }
    }
}
