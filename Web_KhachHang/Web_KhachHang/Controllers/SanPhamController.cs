using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Net;
using Web_KhachHang.Models;
using Web_KhachHang.ViewModels;
using X.PagedList;

namespace Web_KhachHang.Controllers
{
    public class SanPhamController : Controller
    {
        CuaHangBanQuanAoContext db = new CuaHangBanQuanAoContext();
        public async Task<IActionResult> Index(int? page, int? pagesize)
        {
			// Menu Thương hiệu
			List<Ma_Ten> lstThuongHieu = (from hang in db.HangSxes
										select new Ma_Ten { Ma=hang.MaHangSx, Ten=hang.TenHangSx }
										).ToList();
			ViewBag.lstThuongHieu = lstThuongHieu;

			// ========================================================================================
			// PagedList Sản phẩm
            int pageNumber = (page == null || page <= 0 ? 1 : page.Value);
            int pageSize = (pagesize==null || pagesize <= 0 ? 9 : pagesize.Value);
            var lstSanPham = await db.SanPhams.AsNoTracking().ToListAsync();
            PagedList<SanPham> lst = new PagedList<SanPham>(lstSanPham, pageNumber, pageSize);
            return View(lst);
        }

        // ChiTietSanPham
        public async Task<IActionResult> ChiTietSanPham(int id)
        {
            if (id == null)
                return StatusCode((int)HttpStatusCode.BadRequest);
            // Truy vấn dữ liệu sản phẩm
            SanPham sp = await db.SanPhams.Include(x => x.MaHangSxNavigation)
                                          .Include(x => x.MaChatLieuNavigation)
                                          .Include(x => x.MaDtNavigation)
                                          .Include(x => x.MaNuocNavigation)
                                          .Include(x => x.MaLoaiNavigation)
                            .Where(x => x.MaSp == id && x.ConHang == true).FirstOrDefaultAsync();
            if (sp == null)
            {
                return NotFound();
            }
            // Danh sách ảnh sản phẩm
            List<AnhSp> AnhSp = await db.AnhSps.Where(x => x.MaSp == id).ToListAsync();
            ViewBag.AnhSp = AnhSp;
            //--------------------------------------------------------------
            // Danh sách chi tiết sản phẩm của sản phẩm
            List<chitietsp> lstChiTietSP = await (from ctsp in db.ChiTietSanPhams
                                                  join mau in db.MauSacs on ctsp.MaMauSac equals mau.MaMauSac
                                                  join kt in db.KichThuocs on ctsp.MaKichThuoc equals kt.MaKichThuoc
                                                  where ctsp.MaSp == sp.MaSp
                                                  select new chitietsp
                                                  {
                                                      maCTSP = ctsp.MaChiTietSanPham,
                                                      maMau = mau.MaMauSac,
                                                      maKichThuoc = kt.MaKichThuoc,
                                                      mausac = mau.TenMauSac,
                                                      kichthuoc = kt.KichThuoc1,
                                                      giaBan = ctsp.DonGiaBan,
                                                      soLuongTon = ctsp.Slton
                                                  }).ToListAsync();
            ViewBag.lstChiTietSP = lstChiTietSP;

            // Danh sách màu của sản phẩm
            List<MauSac> lstMau = (from ctsp in lstChiTietSP
                                   group ctsp by new { ctsp.maMau, ctsp.mausac } into g // as g
                                   select (new MauSac { MaMauSac = g.Key.maMau, TenMauSac = g.Key.mausac })
                                 ).Distinct().ToList();

            ViewBag.lstMau = lstMau;
            // Danh sách kích thước của sản phẩm
            List<KichThuoc> lstKichThuoc = (from ctsp in lstChiTietSP
                                            group ctsp by new { ctsp.maKichThuoc, ctsp.kichthuoc } into g // as g
                                            select (new KichThuoc { MaKichThuoc = g.Key.maKichThuoc, KichThuoc1 = g.Key.kichthuoc })
                                            ).Distinct().ToList();

            ViewBag.lstKichThuoc = lstKichThuoc;
            //--------------------------------------------------------------
            // Dữ liệu cho _PartialSanPhamBanChay
            List<SanPham> lstSanPhamBanChay = db.SanPhams.Where(x => x.BestSeller == true && x.ConHang == true).ToList();
            ViewBag.lstSanPhamBanChay = lstSanPhamBanChay;
            return View(sp);
        }
        /*
		public ActionResult SanPhamTheoThuongHieu(int? page, int? idTH, int idLoai = 0)
		{
			ViewBag.IdTH = idTH;
			ViewBag.IdLoai = idLoai;
			if (id == null)
				return StatusCode((int)HttpStatusCode.BadRequest);
			IEnumerable<SANPHAM> listSP;
			if (idLoai == 0)
			{
				listSP = db.SANPHAMs.Where(x => x.IdTH == idTH && x.TinhTrang == 1);
			}
			else
			{
				listSP = db.SANPHAMs.Where(x => x.IdLoaiSP == idLoai && x.IdTH == idTH && x.TinhTrang == 1);
			}
			ViewBag.Loai = null;
			if (idLoai != 0)
			{
				ViewBag.Loai = db.LOAISANPHAMs.SingleOrDefault(x => x.IdLoaiSP == idLoai && x.TinhTrang == true);
			}
			ViewBag.TH = db.THUONGHIEUx.SingleOrDefault(x => x.IdTH == idTH && x.TinhTrang == true);


			//So san pham tren 1 trang
			int PageSize = 9;
			//So trang hien tai
			int PageNumber = (page ?? 1);
			ViewBag.IdTH = idTH;
			ViewBag.IdLoai = idLoai;
			return View(listSP.OrderBy(x => x.IdSP).ToPagedList(PageNumber, PageSize));
		}


		public ActionResult SanPhamTheoLoai(int? page, int? idLoai, int idTH = 0)
		{
			ViewBag.IdTH = idTH;
			ViewBag.IdLoai = idLoai;
			if (id == null)
				return StatusCode((int)HttpStatusCode.BadRequest);
			IEnumerable<SANPHAM> listSP;
			if (idTH == 0)
			{
				listSP = db.SANPHAMs.Where(x => x.IdLoaiSP == idLoai && x.TinhTrang == 1);
			}
			else
			{
				listSP = db.SANPHAMs.Where(x => x.IdLoaiSP == idLoai && x.IdTH == idTH && x.TinhTrang == 1);
			}
			ViewBag.TH = null;
			if (idTH != 0)
			{
				ViewBag.TH = db.THUONGHIEUx.SingleOrDefault(x => x.IdTH == idTH && x.TinhTrang == true);
			}

			ViewBag.Loai = db.LOAISANPHAMs.SingleOrDefault(x => x.IdLoaiSP == idLoai && x.TinhTrang == true);
			//So san pham tren 1 trang
			int PageSize = 9;
			//So trang hien tai
			int PageNumber = (page ?? 1);
			ViewBag.IdTH = idTH;
			ViewBag.IdLoai = idLoai;
			return View(listSP.OrderBy(x => x.IdSP).ToPagedList(PageNumber, PageSize));
		}


		public ActionResult SanPhamTheoDanhMuc(int? page, int? idDM, int idTH = 0)
		{
			ViewBag.IdTH = idTH;
			ViewBag.IdDM = idDM;
			if (id == null)
				return StatusCode((int)HttpStatusCode.BadRequest);
			IEnumerable<SANPHAM> listSP;
			if (idTH == 0)
			{
				listSP = db.SANPHAMs.Where(x => x.LOAISANPHAM.DanhMuc == idDM && x.TinhTrang == 1);
			}
			else
			{
				listSP = db.SANPHAMs.Where(x => x.LOAISANPHAM.DanhMuc == idDM && x.IdTH == idTH && x.TinhTrang == 1);
			}
			ViewBag.TH = null;
			if (idTH != 0)
			{
				ViewBag.TH = db.THUONGHIEUx.SingleOrDefault(x => x.IdTH == idTH && x.TinhTrang == true);
			}


			//So san pham tren 1 trang
			int PageSize = 9;
			//So trang hien tai
			int PageNumber = (page ?? 1);
			ViewBag.IdTH = idTH;
			ViewBag.IdDM = idDM;
			return View(listSP.OrderBy(x => x.IdSP).ToPagedList(PageNumber, PageSize));
		}

		*/


    }
}
