//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TTCD1_TranMinhDuc_2210900014.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tmd_HoaDon
    {
        public int MaHD { get; set; }
        public string DiaChiNN { get; set; }
        public Nullable<int> DienThoaiNN { get; set; }
        public Nullable<System.DateTime> NgayDat { get; set; }
        public Nullable<System.DateTime> NgayGiao { get; set; }
        public Nullable<bool> TrangThai { get; set; }
        public Nullable<int> MaKH { get; set; }
        public Nullable<int> MaSP { get; set; }
        public Nullable<int> SoLuong { get; set; }
        public Nullable<decimal> Gia { get; set; }
    
        public virtual Tmd_KhachHang Tmd_KhachHang { get; set; }
        public virtual Tmd_SanPham Tmd_SanPham { get; set; }
    }
}
