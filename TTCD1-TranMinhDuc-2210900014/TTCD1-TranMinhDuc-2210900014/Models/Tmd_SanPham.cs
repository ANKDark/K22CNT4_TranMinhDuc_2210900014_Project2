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
    
    public partial class Tmd_SanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tmd_SanPham()
        {
            this.Tmd_HoaDon = new HashSet<Tmd_HoaDon>();
        }
    
        public int MaSP { get; set; }
        public string TenSP { get; set; }
        public Nullable<int> SoLuong { get; set; }
        public Nullable<System.DateTime> NgayNhap { get; set; }
        public Nullable<decimal> GiaBan { get; set; }
        public Nullable<decimal> GiaNhap { get; set; }
        public Nullable<bool> Sale { get; set; }
        public Nullable<int> SoLuongDaBan { get; set; }
        public Nullable<bool> TinhTrang { get; set; }
        public string img1 { get; set; }
        public string img2 { get; set; }
        public string img3 { get; set; }
        public string MaNSX { get; set; }
        public Nullable<decimal> GiaSale { get; set; }
        public string Mota { get; set; }
        public string LoaiSP { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tmd_HoaDon> Tmd_HoaDon { get; set; }
        public virtual Tmd_NSX Tmd_NSX { get; set; }
    }
}
