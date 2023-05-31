using System.Collections.Generic;
using Web_KhachHang.Models;
namespace Web_KhachHang.Repository
{
    public interface ILoaiSpRepository
    {
        LoaiSp Add(LoaiSp loaiSP);
        LoaiSp Update(LoaiSp loaiSP);
        LoaiSp Delete(int maLoaiSP);
        LoaiSp GetLoaiSp(int maLoaiSP);
        IEnumerable<LoaiSp> GetAllLoaiSp();
    }
}
