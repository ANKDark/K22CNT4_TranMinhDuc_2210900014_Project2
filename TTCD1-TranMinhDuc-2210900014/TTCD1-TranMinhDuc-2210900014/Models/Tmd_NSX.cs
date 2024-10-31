using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TTCD1_TranMinhDuc_2210900014.Models
{
    public partial class Tmd_NSX
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tmd_NSX()
        {
            this.Tmd_SanPham = new HashSet<Tmd_SanPham>();
        }

        [Required(ErrorMessage = "Mã NSX là bắt buộc.")]
        [StringLength(10, ErrorMessage = "Mã NSX không được vượt quá 10 ký tự.")]
        public string MaNSX { get; set; }

        [Required(ErrorMessage = "Tên NSX là bắt buộc.")]
        [StringLength(100, ErrorMessage = "Tên NSX không được vượt quá 100 ký tự.")]
        public string TenNSX { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tmd_SanPham> Tmd_SanPham { get; set; }
    }
}
