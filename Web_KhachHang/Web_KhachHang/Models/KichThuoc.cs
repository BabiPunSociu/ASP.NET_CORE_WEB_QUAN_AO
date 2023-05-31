using System;
using System.Collections.Generic;

namespace Web_KhachHang.Models;

public partial class KichThuoc
{
    public int MaKichThuoc { get; set; }

    public string KichThuoc1 { get; set; } = null!;

    public virtual ICollection<ChiTietSanPham> ChiTietSanPhams { get; set; } = new List<ChiTietSanPham>();
}
