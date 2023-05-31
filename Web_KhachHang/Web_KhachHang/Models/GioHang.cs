using System;
using System.Collections.Generic;

namespace Web_KhachHang.Models;

public partial class GioHang
{
    public int SoLuong { get; set; }

    public bool? TrangThai { get; set; }

    public int MaChiTietSanPham { get; set; }

    public int MaKhachHang { get; set; }

    public virtual ChiTietSanPham MaChiTietSanPhamNavigation { get; set; } = null!;

    public virtual KhachHang MaKhachHangNavigation { get; set; } = null!;
}
