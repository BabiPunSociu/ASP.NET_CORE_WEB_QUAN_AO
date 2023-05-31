using System;
using System.Collections.Generic;

namespace Web_Admin.Models;

public partial class ChiTietHdn
{
    public int SoLuongNhap { get; set; }

    public decimal DonGiaNhap { get; set; }

    public string? GhiChu { get; set; }

    public int MaChiTietSanPham { get; set; }

    public int MaHdn { get; set; }

    public virtual ChiTietSanPham MaChiTietSanPhamNavigation { get; set; } = null!;

    public virtual HoaDonNhap MaHdnNavigation { get; set; } = null!;
}
