using Microsoft.AspNetCore.Mvc;
using Web_KhachHang.Repository;

namespace Web_KhachHang.ViewComponents
{
	public class LoaiSpViewComponent:ViewComponent
	{
		private readonly ILoaiSpRepository _LoaiSp;
		public LoaiSpViewComponent(ILoaiSpRepository loaispRepository)
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
