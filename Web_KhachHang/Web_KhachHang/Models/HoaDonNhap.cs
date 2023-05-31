using System;
using System.Collections.Generic;

namespace Web_KhachHang.Models;

public partial class HoaDonNhap
{
    public int MaHdn { get; set; }

    public DateTime NgayNhap { get; set; }

    public decimal? TongTienHd { get; set; }

    public string? MaSoThue { get; set; }

    public string? ThongTinThue { get; set; }

    public string PhuongThucThanhToan { get; set; } = null!;

    public string? GhiChu { get; set; }

    public int MaNhanVien { get; set; }

    public virtual ICollection<ChiTietHdn> ChiTietHdns { get; set; } = new List<ChiTietHdn>();

    public virtual NhanVien MaNhanVienNavigation { get; set; } = null!;
}
