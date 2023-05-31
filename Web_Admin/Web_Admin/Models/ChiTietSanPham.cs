using System;
using System.Collections.Generic;

namespace Web_Admin.Models;

public partial class ChiTietSanPham
{
    public int MaChiTietSanPham { get; set; }

    public string? AnhDaiDien { get; set; }

    public string? Video { get; set; }

    public decimal DonGiaBan { get; set; }

    public decimal DonGiaNhap { get; set; }

    public int Slton { get; set; }

    public int MaSp { get; set; }

    public int MaMauSac { get; set; }

    public int MaKichThuoc { get; set; }

    public int? MaKm { get; set; }

    public virtual ICollection<ChiTietHdb> ChiTietHdbs { get; set; } = new List<ChiTietHdb>();

    public virtual ICollection<ChiTietHdn> ChiTietHdns { get; set; } = new List<ChiTietHdn>();

    public virtual ICollection<GioHang> GioHangs { get; set; } = new List<GioHang>();

    public virtual KichThuoc MaKichThuocNavigation { get; set; } = null!;

    public virtual KhuyenMai? MaKmNavigation { get; set; }

    public virtual MauSac MaMauSacNavigation { get; set; } = null!;

    public virtual SanPham MaSpNavigation { get; set; } = null!;
}
