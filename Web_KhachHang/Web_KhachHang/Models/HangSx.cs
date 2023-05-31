using System;
using System.Collections.Generic;

namespace Web_KhachHang.Models;

public partial class HangSx
{
    public int MaHangSx { get; set; }

    public string TenHangSx { get; set; } = null!;

    public int? SldaBan { get; set; }

    public virtual ICollection<SanPham> SanPhams { get; set; } = new List<SanPham>();
}
