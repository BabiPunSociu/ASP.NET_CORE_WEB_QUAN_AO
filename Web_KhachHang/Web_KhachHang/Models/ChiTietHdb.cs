using System;
using System.Collections.Generic;

namespace Web_KhachHang.Models;

public partial class ChiTietHdb
{
    public int SoLuongBan { get; set; }

    public decimal DonGiaBan { get; set; }

    public string? GhiChu { get; set; }

    public int MaHdb { get; set; }

    public int MaChiTietSanPham { get; set; }

    public virtual ChiTietSanPham MaChiTietSanPhamNavigation { get; set; } = null!;

    public virtual HoaDonBan MaHdbNavigation { get; set; } = null!;
}
