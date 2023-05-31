using System;
using System.Collections.Generic;

namespace Web_KhachHang.Models;

public partial class ChatLieu
{
    public int MaChatLieu { get; set; }

    public string ChatLieu1 { get; set; } = null!;

    public virtual ICollection<SanPham> SanPhams { get; set; } = new List<SanPham>();
}
