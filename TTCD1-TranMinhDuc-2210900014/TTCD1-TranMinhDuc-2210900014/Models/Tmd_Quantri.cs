using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TTCD1_TranMinhDuc_2210900014.Models
{
    public partial class Tmd_Quantri
    {
        public int MaAdmin { get; set; }

        [Required(ErrorMessage = "Họ tên admin là bắt buộc.")]
        public string HotenAdmin { get; set; }

        [Required(ErrorMessage = "Mật khẩu là bắt buộc.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Mật khẩu phải có ít nhất 6 ký tự và tối đa 100 ký tự.")]
        public string MatkhauAdmin { get; set; }

        public Nullable<bool> TrangThai { get; set; }

        [Required(ErrorMessage = "Tài khoản là bắt buộc.")]
        [StringLength(50, ErrorMessage = "Tài khoản không được vượt quá 50 ký tự.")]
        public string Taikhoan { get; set; }
    }
}
