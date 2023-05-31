using System;
using System.Collections.Generic;

namespace Web_Admin.Models;

public partial class MauSac
{
    public int MaMauSac { get; set; }

    public string TenMauSac { get; set; } = null!;

    public virtual ICollection<ChiTietSanPham> ChiTietSanPhams { get; set; } = new List<ChiTietSanPham>();
}
