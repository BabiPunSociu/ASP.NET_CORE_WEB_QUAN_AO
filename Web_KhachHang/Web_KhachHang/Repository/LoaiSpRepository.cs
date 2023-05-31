using System;
using System.Collections.Generic;
using Web_KhachHang.Models;

namespace Web_KhachHang.Repository
{
    public class LoaiSpRepository : ILoaiSpRepository
    {
        private readonly CuaHangBanQuanAoContext _context;
        public LoaiSpRepository(CuaHangBanQuanAoContext context)
        {
            _context = context;
        }

        public LoaiSp Add(LoaiSp loaiSP)
        {
            _context.LoaiSps.Add(loaiSP);
            _context.SaveChanges();
            return loaiSP;
        }

        public IEnumerable<LoaiSp> GetAllLoaiSp()
        {
            return _context.LoaiSps;
        }

        public LoaiSp GetLoaiSp(int maLoaiSP)
        {
            return _context.LoaiSps.Find(maLoaiSP);
        }

        public LoaiSp Update(LoaiSp loaiSP)
        {
            _context.Update(loaiSP);
            _context.SaveChanges();
            return loaiSP;
        }

        public LoaiSp Delete(int maLoaiSP)
        {
            throw new NotImplementedException();
        }
    }
}
