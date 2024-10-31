using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using TTCD1_TranMinhDuc_2210900014.Models;

namespace TTCD1_TranMinhDuc_2210900014.Models
{
    public partial class Tmd_SanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tmd_SanPham()
        {
            this.Tmd_HoaDon = new HashSet<Tmd_HoaDon>();
        }

        public int MaSP { get; set; }

        [Required(ErrorMessage = "Tên sản phẩm là bắt buộc.")]
        [StringLength(100, ErrorMessage = "Tên sản phẩm không được vượt quá 100 ký tự.")]
        public string TenSP { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Số lượng phải lớn hơn hoặc bằng 0.")]
        public Nullable<int> SoLuong { get; set; }

        public Nullable<System.DateTime> NgayNhap { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Giá bán phải lớn hơn 0.")]
        public Nullable<decimal> GiaBan { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Giá nhập phải lớn hơn 0.")]
        public Nullable<decimal> GiaNhap { get; set; }

        public Nullable<bool> Sale { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Số lượng đã bán phải lớn hơn hoặc bằng 0.")]
        public Nullable<int> SoLuongDaBan { get; set; }

        public Nullable<bool> TinhTrang { get; set; }

        public string img1 { get; set; }

        public string img2 { get; set; }

        public string img3 { get; set; }

        public string MaNSX { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Giá sale phải lớn hơn 0.")]
        public Nullable<decimal> GiaSale { get; set; }
        [AllowHtml]
        public string Mota { get; set; }

        [Required(ErrorMessage = "Loại sản phẩm là bắt buộc.")]
        [RegularExpression(@"^(Điện thoại|Apple|Laptop|Tablet|Màn hình|Phụ kiện|Đồng hồ|Âm thanh|Smart home|Điện máy)$",
            ErrorMessage = "Loại sản phẩm không hợp lệ.")]
        public string LoaiSP { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tmd_HoaDon> Tmd_HoaDon { get; set; }
        public virtual Tmd_NSX Tmd_NSX { get; set; }
    }
}
