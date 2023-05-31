using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Drawing;
using Web_KhachHang.Common;
using Web_KhachHang.Extension;
using Web_KhachHang.Models;
using Web_KhachHang.ViewModels;

namespace Web_KhachHang.Controllers
{
    public class HomeController : Controller
    {
        CuaHangBanQuanAoContext db = new CuaHangBanQuanAoContext();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //======================================================================================================
        public async Task<IActionResult> Index()
        {
            // Dữ liệu cho _PartialBannerDactinh

            // Lấy top 4 đặc tính mà sản phẩm còn hàng
            /*
            Code SQL
            Select top(4) LoaiDacTinh.MaDT, TenDT
            from LoaiDacTinh join SanPham on LoaiDacTinh.MaDT=SanPham.MaDT
            Where (SanPham.ConHang=1)
            Group by LoaiDacTinh.MaDT, TenDT
            */
            List<Ma_Ten> top4DacTinh =await (from DacTinh in db.LoaiDacTinhs
                                        join SanPham in db.SanPhams on DacTinh.MaDt equals SanPham.MaDt
                                        where SanPham.ConHang == true
                                        group DacTinh by new { DacTinh.MaDt, DacTinh.TenDt } into g // as g
                                        select (new Ma_Ten { Ma = g.Key.MaDt, Ten = g.Key.TenDt })
                               ).Take(4).ToListAsync();

            ViewBag.top4DacTinh = top4DacTinh;
            //-----------------------------------------------------------------------------
            // Dữ liệu cho _PartialThuongHieuNoiBat

            // Sắp xếp các thương hiệu theo giảm dần của slDaban => select top(5)
            var lstThuongHieu =await (from HangSX in db.HangSxes
                                 join SP in db.SanPhams on HangSX.MaHangSx equals SP.MaHangSx
                                 where SP.ConHang == true
                                 orderby HangSX.SldaBan
                                 select new Ma_Ten { Ma = HangSX.MaHangSx, Ten = HangSX.TenHangSx }).Take(5).ToListAsync();

            ViewBag.lstThuongHieu = lstThuongHieu;
            //-----------------------------------------------------------------------------
            // Dữ liệu cho _PartialSanPhamBanChay
            List<SanPham> lstSanPhamBanChay = await db.SanPhams.Where(x => x.BestSeller == true && x.ConHang == true).ToListAsync();
            ViewBag.lstSanPhamBanChay = lstSanPhamBanChay;
            return View();
        }

        //======================================================================================================
        [HttpGet]
        public ActionResult DangKi()
        {
            ViewBag.ThongBao = "";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DangKi(KhachHang_Account kh_ac)
        {
            if (ModelState.IsValid)
            {
                // Kiểm tra email đã tồn tại chưa?
                if (!AccountExists(kh_ac.Account.Email))
                {
                    // Thêm newAccount
                    Account newAccount = kh_ac.Account;
                    db.Add(newAccount);
                    await db.SaveChangesAsync();

                    // Thêm newKhachHang
                    KhachHang newKhachHang = kh_ac.KhachHang;
                    newKhachHang.Email = newAccount.Email;
                    newKhachHang.AnhDaiDien = "avatar_default.jpg";
                    db.Add(newKhachHang);
                    await db.SaveChangesAsync();

                    // Thêm dữ liệu KhachHang vào session
                    HttpContext.Session.Set<KhachHang>("user", newKhachHang);

                    return RedirectToAction(nameof(Index));
                }
                // Đưa ra thông báo email đã tồn tại
                ViewBag.ThongBao = "Email đã tồn tại";
            }
            return View(kh_ac);
        }
        public bool AccountExists(string email)
        {
            return db.Accounts.Any(e => e.Email == email);
        }
        //======================================================================================================
        public IActionResult DangNhap()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DangNhap(Account account)
        {
            if (ModelState.IsValid)
            {
                if (account != null)
                {
                    var acc = db.Accounts.Where(x => x.Email == account.Email && x.Password == account.Password).FirstOrDefault();
                    if (acc != null)
                    {
                        // Thêm dữ liệu KhachHang tương ứng vào session
                        KhachHang kh = db.KhachHangs.Where(x => x.Email.Equals(acc.Email)).FirstOrDefault();
                        HttpContext.Session.Set<KhachHang>("user", kh);

                        return RedirectToAction(nameof(Index));
                    }
                }
                // Đưa ra thông báo
                ViewBag.ThongBao = "Email hoặc Password không đúng, vui lòng thử lại";
            }
            return View(account);
        }




        //======================================================================================================
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}