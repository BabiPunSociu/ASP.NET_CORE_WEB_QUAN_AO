using System;
using System.Collections.Generic;

namespace Web_KhachHang.Models;

public partial class HoaDonBan
{
    public int MaHdb { get; set; }

    public DateTime NgayBan { get; set; }

    public decimal? TongTienHd { get; set; }

    public string PhuongThucThanhToan { get; set; } = null!;

    public string? MaSoThue { get; set; }

    public string? ThongTinThue { get; set; }

    public string? GhiChu { get; set; }

    public DateTime NgayDatHang { get; set; }

    public int MaKhachHang { get; set; }

    public int MaNhanVien { get; set; }

    public int? MaKm { get; set; }

    public virtual ICollection<ChiTietHdb> ChiTietHdbs { get; set; } = new List<ChiTietHdb>();

    public virtual KhachHang MaKhachHangNavigation { get; set; } = null!;

    public virtual KhuyenMai? MaKmNavigation { get; set; }

    public virtual NhanVien MaNhanVienNavigation { get; set; } = null!;

    public virtual ICollection<TrangThaiDonHang> TrangThaiDonHangs { get; set; } = new List<TrangThaiDonHang>();
}
