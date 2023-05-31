using System;
using System.Collections.Generic;

namespace Web_KhachHang.Models;

public partial class KhuyenMai
{
    public int MaKm { get; set; }

    public string TenKm { get; set; } = null!;

    public DateTime NgayBd { get; set; }

    public DateTime NgayKt { get; set; }

    public bool TinhTrang { get; set; }

    public decimal GiaTri { get; set; }

    public string? ChiTiet { get; set; }

    public virtual ICollection<ChiTietSanPham> ChiTietSanPhams { get; set; } = new List<ChiTietSanPham>();

    public virtual ICollection<HoaDonBan> HoaDonBans { get; set; } = new List<HoaDonBan>();
}
