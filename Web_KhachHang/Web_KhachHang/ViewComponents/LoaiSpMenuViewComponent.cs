
using Microsoft.AspNetCore.Mvc;
using Web_KhachHang.Repository;

namespace WebApplication_Nhap.ViewComponents
{
    public class LoaiSpMenuViewComponent : ViewComponent
    {
        private readonly ILoaiSpRepository _LoaiSp;
        public LoaiSpMenuViewComponent(ILoaiSpRepository loaispRepository)
        {
            _LoaiSp = loaispRepository;
        }
        public IViewComponentResult Invoke()
        {
            var loai = _LoaiSp.GetAllLoaiSp().OrderBy(x => x.Loai);
            return View(loai);
        }
    }
}