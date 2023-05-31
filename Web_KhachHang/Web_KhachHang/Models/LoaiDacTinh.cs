using System;
using System.Collections.Generic;

namespace Web_KhachHang.Models;

public partial class LoaiDacTinh
{
    public int MaDt { get; set; }

    public string TenDt { get; set; } = null!;

    public virtual ICollection<SanPham> SanPhams { get; set; } = new List<SanPham>();
}
