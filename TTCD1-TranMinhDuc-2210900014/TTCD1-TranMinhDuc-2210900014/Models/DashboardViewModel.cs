using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TTCD1_TranMinhDuc_2210900014.Models
{

        public class DashboardViewModel
        {
            public IEnumerable<Tmd_SanPham> SanPhams { get; set; }
            public IEnumerable<Tmd_KhachHang> KhachHangs { get; set; }
            public IEnumerable<Tmd_HoaDon> HoaDons { get; set; }
            public IEnumerable<Tmd_NSX> NhaSanXuats { get; set; }
            public IEnumerable<Tmd_Quantri> QuanTris { get; set; }
        }
    }
