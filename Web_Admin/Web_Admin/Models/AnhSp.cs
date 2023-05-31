using System;
using System.Collections.Generic;

namespace Web_Admin.Models;

public partial class AnhSp
{
    public string TenFileAnh { get; set; } = null!;

    public string? Vitri { get; set; }

    public int MaSp { get; set; }

    public virtual SanPham MaSpNavigation { get; set; } = null!;
}
