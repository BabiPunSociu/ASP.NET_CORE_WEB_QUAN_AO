using System;
using System.Collections.Generic;

namespace Web_KhachHang.Models;

public partial class SanPham
{
    public int MaSp { get; set; }

    public string TenSp { get; set; } = null!;

    public DateTime? ThoiGianBaoHanh { get; set; }

    public string? GioiThieuSanPham { get; set; }

    public double? ChietKhau { get; set; }

    public string? AnhDaiDien { get; set; }

    public decimal? GiaLonNhat { get; set; }

    public decimal? GiaNhoNhat { get; set; }

    public int MaChatLieu { get; set; }

    public int MaLoai { get; set; }

    public int MaDt { get; set; }

    public int MaHangSx { get; set; }

    public int MaNuoc { get; set; }

    public bool BestSeller { get; set; }

    public bool ConHang { get; set; }

    public virtual ICollection<AnhSp> AnhSps { get; set; } = new List<AnhSp>();

    public virtual ICollection<ChiTietSanPham> ChiTietSanPhams { get; set; } = new List<ChiTietSanPham>();

    public virtual ChatLieu MaChatLieuNavigation { get; set; } = null!;

    public virtual LoaiDacTinh MaDtNavigation { get; set; } = null!;

    public virtual HangSx MaHangSxNavigation { get; set; } = null!;

    public virtual LoaiSp MaLoaiNavigation { get; set; } = null!;

    public virtual QuocGium MaNuocNavigation { get; set; } = null!;
}
