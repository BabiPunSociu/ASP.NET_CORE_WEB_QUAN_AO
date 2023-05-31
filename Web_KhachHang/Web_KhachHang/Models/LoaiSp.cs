using System;
using System.Collections.Generic;

namespace Web_KhachHang.Models;

public partial class LoaiSp
{
    public int MaLoai { get; set; }

    public string Loai { get; set; } = null!;

    public virtual ICollection<SanPham> SanPhams { get; set; } = new List<SanPham>();
}
