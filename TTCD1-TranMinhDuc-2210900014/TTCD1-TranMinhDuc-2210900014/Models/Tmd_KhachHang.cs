using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TTCD1_TranMinhDuc_2210900014.Models
{
    public partial class Tmd_KhachHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tmd_KhachHang()
        {
            this.Tmd_HoaDon = new HashSet<Tmd_HoaDon>();
        }

        public int MaKH { get; set; }

        [Required(ErrorMessage = "Họ tên là bắt buộc.")]
        [StringLength(100, ErrorMessage = "Họ tên không được vượt quá 100 ký tự.")]
        public string HoTen { get; set; }

        [Required(ErrorMessage = "Tài khoản là bắt buộc.")]
        [StringLength(50, ErrorMessage = "Tài khoản không được vượt quá 50 ký tự.")]
        public string TaiKhoan { get; set; }

        [Required(ErrorMessage = "Điện thoại là bắt buộc.")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Số điện thoại không hợp lệ. Phải có 10 chữ số.")]
        public Nullable<int> DienThoai { get; set; }

        [Required(ErrorMessage = "Email là bắt buộc.")]
        [EmailAddress(ErrorMessage = "Địa chỉ email không hợp lệ.")]
        public string Email { get; set; }

        public Nullable<bool> GioiTinh { get; set; }

        [Required(ErrorMessage = "Mật khẩu là bắt buộc.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Mật khẩu phải có ít nhất 6 ký tự.")]
        public string MatKhau { get; set; }

        public Nullable<System.DateTime> NgaySinh { get; set; }

        public Nullable<bool> TrangThai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tmd_HoaDon> Tmd_HoaDon { get; set; }
    }
}
