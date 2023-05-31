using System;
using System.Collections.Generic;

namespace Web_Admin.Models;

public partial class TrangThaiDonHang
{
    public int MaTrangThaiDh { get; set; }

    public bool DaXacNhan { get; set; }

    public DateTime? NgayXacNhan { get; set; }

    public bool DangGiaHang { get; set; }

    public DateTime? NgayGiaoHang { get; set; }

    public bool DaGiaoThanhCong { get; set; }

    public DateTime? NgayGiaoThanhCong { get; set; }

    public bool HuyDon { get; set; }

    public DateTime? NgayHuyHon { get; set; }

    public int MaHdb { get; set; }

    public virtual HoaDonBan MaHdbNavigation { get; set; } = null!;
}
