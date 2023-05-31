using System;
using System.Collections.Generic;

namespace Web_Admin.Models;

public partial class QuocGium
{
    public int MaNuoc { get; set; }

    public string TenNuoc { get; set; } = null!;

    public virtual ICollection<SanPham> SanPhams { get; set; } = new List<SanPham>();
}
