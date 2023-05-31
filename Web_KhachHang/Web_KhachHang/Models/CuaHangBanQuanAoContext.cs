using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Web_KhachHang.Models;

public partial class CuaHangBanQuanAoContext : DbContext
{
    public CuaHangBanQuanAoContext()
    {
    }

    public CuaHangBanQuanAoContext(DbContextOptions<CuaHangBanQuanAoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<AnhSp> AnhSps { get; set; }

    public virtual DbSet<ChatLieu> ChatLieus { get; set; }

    public virtual DbSet<ChiTietHdb> ChiTietHdbs { get; set; }

    public virtual DbSet<ChiTietHdn> ChiTietHdns { get; set; }

    public virtual DbSet<ChiTietSanPham> ChiTietSanPhams { get; set; }

    public virtual DbSet<GioHang> GioHangs { get; set; }

    public virtual DbSet<HangSx> HangSxes { get; set; }

    public virtual DbSet<HoaDonBan> HoaDonBans { get; set; }

    public virtual DbSet<HoaDonNhap> HoaDonNhaps { get; set; }

    public virtual DbSet<KhachHang> KhachHangs { get; set; }

    public virtual DbSet<KhuyenMai> KhuyenMais { get; set; }

    public virtual DbSet<KichThuoc> KichThuocs { get; set; }

    public virtual DbSet<LoaiDacTinh> LoaiDacTinhs { get; set; }

    public virtual DbSet<LoaiSp> LoaiSps { get; set; }

    public virtual DbSet<MauSac> MauSacs { get; set; }

    public virtual DbSet<NhanVien> NhanViens { get; set; }

    public virtual DbSet<QuocGium> QuocGia { get; set; }

    public virtual DbSet<SanPham> SanPhams { get; set; }

    public virtual DbSet<TrangThaiDonHang> TrangThaiDonHangs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DUNGNGUYEN;Initial Catalog=CuaHangBanQuanAo;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.Email).HasName("PK__Account__A9D1053507EE4BC6");

            entity.ToTable("Account");

            entity.Property(e => e.Email).HasMaxLength(400);
            entity.Property(e => e.LoaiUser).HasMaxLength(400);
            entity.Property(e => e.Password)
                .HasMaxLength(400)
                .HasColumnName("password");
        });

        modelBuilder.Entity<AnhSp>(entity =>
        {
            entity.HasKey(e => e.TenFileAnh).HasName("PK__AnhSP__8E7F362109484D9C");

            entity.ToTable("AnhSP");

            entity.Property(e => e.TenFileAnh).HasMaxLength(400);
            entity.Property(e => e.MaSp).HasColumnName("MaSP");
            entity.Property(e => e.Vitri).HasMaxLength(400);

            entity.HasOne(d => d.MaSpNavigation).WithMany(p => p.AnhSps)
                .HasForeignKey(d => d.MaSp)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__AnhSP__MaSP__656C112C");
        });

        modelBuilder.Entity<ChatLieu>(entity =>
        {
            entity.HasKey(e => e.MaChatLieu).HasName("PK__ChatLieu__453995BC3BF93505");

            entity.ToTable("ChatLieu");

            entity.Property(e => e.MaChatLieu).ValueGeneratedNever();
            entity.Property(e => e.ChatLieu1)
                .HasMaxLength(400)
                .HasColumnName("ChatLieu");
        });

        modelBuilder.Entity<ChiTietHdb>(entity =>
        {
            entity.HasKey(e => new { e.MaHdb, e.MaChiTietSanPham }).HasName("PK__ChiTietH__26FBEAC1A18D2B27");

            entity.ToTable("ChiTietHDB");

            entity.Property(e => e.MaHdb).HasColumnName("MaHDB");
            entity.Property(e => e.DonGiaBan).HasColumnType("money");
            entity.Property(e => e.GhiChu).HasMaxLength(400);

            entity.HasOne(d => d.MaChiTietSanPhamNavigation).WithMany(p => p.ChiTietHdbs)
                .HasForeignKey(d => d.MaChiTietSanPham)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChiTietHD__MaChi__70DDC3D8");

            entity.HasOne(d => d.MaHdbNavigation).WithMany(p => p.ChiTietHdbs)
                .HasForeignKey(d => d.MaHdb)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChiTietHD__MaHDB__6FE99F9F");
        });

        modelBuilder.Entity<ChiTietHdn>(entity =>
        {
            entity.HasKey(e => new { e.MaChiTietSanPham, e.MaHdn }).HasName("PK__ChiTietH__D5792D3C89EC0336");

            entity.ToTable("ChiTietHDN");

            entity.Property(e => e.MaHdn).HasColumnName("MaHDN");
            entity.Property(e => e.DonGiaNhap).HasColumnType("money");
            entity.Property(e => e.GhiChu).HasMaxLength(400);

            entity.HasOne(d => d.MaChiTietSanPhamNavigation).WithMany(p => p.ChiTietHdns)
                .HasForeignKey(d => d.MaChiTietSanPham)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChiTietHD__MaChi__5DCAEF64");

            entity.HasOne(d => d.MaHdnNavigation).WithMany(p => p.ChiTietHdns)
                .HasForeignKey(d => d.MaHdn)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChiTietHD__MaHDN__5EBF139D");
        });

        modelBuilder.Entity<ChiTietSanPham>(entity =>
        {
            entity.HasKey(e => e.MaChiTietSanPham).HasName("PK__ChiTietS__A6B023B0F0D9BAF6");

            entity.ToTable("ChiTietSanPham");

            entity.Property(e => e.MaChiTietSanPham).ValueGeneratedNever();
            entity.Property(e => e.AnhDaiDien).HasMaxLength(400);
            entity.Property(e => e.DonGiaBan).HasColumnType("money");
            entity.Property(e => e.DonGiaNhap).HasColumnType("money");
            entity.Property(e => e.MaKm).HasColumnName("MaKM");
            entity.Property(e => e.MaSp).HasColumnName("MaSP");
            entity.Property(e => e.Slton).HasColumnName("SLTon");
            entity.Property(e => e.Video).HasMaxLength(400);

            entity.HasOne(d => d.MaKichThuocNavigation).WithMany(p => p.ChiTietSanPhams)
                .HasForeignKey(d => d.MaKichThuoc)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChiTietSa__MaKic__571DF1D5");

            entity.HasOne(d => d.MaKmNavigation).WithMany(p => p.ChiTietSanPhams)
                .HasForeignKey(d => d.MaKm)
                .HasConstraintName("FK__ChiTietSan__MaKM__5812160E");

            entity.HasOne(d => d.MaMauSacNavigation).WithMany(p => p.ChiTietSanPhams)
                .HasForeignKey(d => d.MaMauSac)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChiTietSa__MaMau__5629CD9C");

            entity.HasOne(d => d.MaSpNavigation).WithMany(p => p.ChiTietSanPhams)
                .HasForeignKey(d => d.MaSp)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChiTietSan__MaSP__5535A963");
        });

        modelBuilder.Entity<GioHang>(entity =>
        {
            entity.HasKey(e => new { e.MaChiTietSanPham, e.MaKhachHang }).HasName("PK__GioHang__EE3D0CBEA9C190C2");

            entity.ToTable("GioHang");

            entity.HasOne(d => d.MaChiTietSanPhamNavigation).WithMany(p => p.GioHangs)
                .HasForeignKey(d => d.MaChiTietSanPham)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__GioHang__MaChiTi__619B8048");

            entity.HasOne(d => d.MaKhachHangNavigation).WithMany(p => p.GioHangs)
                .HasForeignKey(d => d.MaKhachHang)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__GioHang__MaKhach__628FA481");
        });

        modelBuilder.Entity<HangSx>(entity =>
        {
            entity.HasKey(e => e.MaHangSx).HasName("PK__HangSX__8C6D28FEDA5EB782");

            entity.ToTable("HangSX");

            entity.Property(e => e.MaHangSx)
                .ValueGeneratedNever()
                .HasColumnName("MaHangSX");
            entity.Property(e => e.SldaBan).HasColumnName("SLDaBan");
            entity.Property(e => e.TenHangSx)
                .HasMaxLength(400)
                .HasColumnName("TenHangSX");
        });

        modelBuilder.Entity<HoaDonBan>(entity =>
        {
            entity.HasKey(e => e.MaHdb).HasName("PK__HoaDonBa__3C90E8FA4521532C");

            entity.ToTable("HoaDonBan");

            entity.Property(e => e.MaHdb)
                .ValueGeneratedNever()
                .HasColumnName("MaHDB");
            entity.Property(e => e.GhiChu).HasMaxLength(400);
            entity.Property(e => e.MaKm).HasColumnName("MaKM");
            entity.Property(e => e.MaSoThue).HasMaxLength(400);
            entity.Property(e => e.NgayBan).HasColumnType("datetime");
            entity.Property(e => e.NgayDatHang).HasColumnType("datetime");
            entity.Property(e => e.PhuongThucThanhToan).HasMaxLength(400);
            entity.Property(e => e.ThongTinThue).HasMaxLength(400);
            entity.Property(e => e.TongTienHd)
                .HasColumnType("money")
                .HasColumnName("TongTienHD");

            entity.HasOne(d => d.MaKhachHangNavigation).WithMany(p => p.HoaDonBans)
                .HasForeignKey(d => d.MaKhachHang)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__HoaDonBan__MaKha__68487DD7");

            entity.HasOne(d => d.MaKmNavigation).WithMany(p => p.HoaDonBans)
                .HasForeignKey(d => d.MaKm)
                .HasConstraintName("FK__HoaDonBan__MaKM__6A30C649");

            entity.HasOne(d => d.MaNhanVienNavigation).WithMany(p => p.HoaDonBans)
                .HasForeignKey(d => d.MaNhanVien)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__HoaDonBan__MaNha__693CA210");
        });

        modelBuilder.Entity<HoaDonNhap>(entity =>
        {
            entity.HasKey(e => e.MaHdn).HasName("PK__HoaDonNh__3C90E8C63CA6B6AD");

            entity.ToTable("HoaDonNhap");

            entity.Property(e => e.MaHdn)
                .ValueGeneratedNever()
                .HasColumnName("MaHDN");
            entity.Property(e => e.GhiChu).HasMaxLength(400);
            entity.Property(e => e.MaSoThue).HasMaxLength(400);
            entity.Property(e => e.NgayNhap).HasColumnType("datetime");
            entity.Property(e => e.PhuongThucThanhToan).HasMaxLength(400);
            entity.Property(e => e.ThongTinThue).HasMaxLength(400);
            entity.Property(e => e.TongTienHd)
                .HasColumnType("money")
                .HasColumnName("TongTienHD");

            entity.HasOne(d => d.MaNhanVienNavigation).WithMany(p => p.HoaDonNhaps)
                .HasForeignKey(d => d.MaNhanVien)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__HoaDonNha__MaNha__4BAC3F29");
        });

        modelBuilder.Entity<KhachHang>(entity =>
        {
            entity.HasKey(e => e.MaKhachHang).HasName("PK__KhachHan__88D2F0E537B0B603");

            entity.ToTable("KhachHang");

            entity.Property(e => e.MaKhachHang).ValueGeneratedNever();
            entity.Property(e => e.AnhDaiDien).HasMaxLength(400);
            entity.Property(e => e.DiaChi).HasMaxLength(400);
            entity.Property(e => e.Email).HasMaxLength(400);
            entity.Property(e => e.GhiChu).HasMaxLength(400);
            entity.Property(e => e.LoaiKhachHang).HasMaxLength(400);
            entity.Property(e => e.NgaySinh).HasColumnType("datetime");
            entity.Property(e => e.SoDienThoai).HasMaxLength(10);
            entity.Property(e => e.TenKhachHang).HasMaxLength(400);

            entity.HasOne(d => d.EmailNavigation).WithMany(p => p.KhachHangs)
                .HasForeignKey(d => d.Email)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__KhachHang__Email__5AEE82B9");
        });

        modelBuilder.Entity<KhuyenMai>(entity =>
        {
            entity.HasKey(e => e.MaKm).HasName("PK__KhuyenMa__2725CF152FB0039A");

            entity.ToTable("KhuyenMai");

            entity.Property(e => e.MaKm)
                .ValueGeneratedNever()
                .HasColumnName("MaKM");
            entity.Property(e => e.ChiTiet).HasMaxLength(400);
            entity.Property(e => e.GiaTri).HasColumnType("money");
            entity.Property(e => e.NgayBd)
                .HasColumnType("datetime")
                .HasColumnName("NgayBD");
            entity.Property(e => e.NgayKt)
                .HasColumnType("datetime")
                .HasColumnName("NgayKT");
            entity.Property(e => e.TenKm)
                .HasMaxLength(400)
                .HasColumnName("TenKM");
        });

        modelBuilder.Entity<KichThuoc>(entity =>
        {
            entity.HasKey(e => e.MaKichThuoc).HasName("PK__KichThuo__22BFD6642BF2EF0B");

            entity.ToTable("KichThuoc");

            entity.Property(e => e.MaKichThuoc).ValueGeneratedNever();
            entity.Property(e => e.KichThuoc1)
                .HasMaxLength(400)
                .HasColumnName("KichThuoc");
        });

        modelBuilder.Entity<LoaiDacTinh>(entity =>
        {
            entity.HasKey(e => e.MaDt).HasName("PK__LoaiDacT__27258655036957DF");

            entity.ToTable("LoaiDacTinh");

            entity.Property(e => e.MaDt)
                .ValueGeneratedNever()
                .HasColumnName("MaDT");
            entity.Property(e => e.TenDt)
                .HasMaxLength(400)
                .HasColumnName("TenDT");
        });

        modelBuilder.Entity<LoaiSp>(entity =>
        {
            entity.HasKey(e => e.MaLoai).HasName("PK__LoaiSP__730A57597ECAC230");

            entity.ToTable("LoaiSP");

            entity.Property(e => e.MaLoai).ValueGeneratedNever();
            entity.Property(e => e.Loai).HasMaxLength(400);
        });

        modelBuilder.Entity<MauSac>(entity =>
        {
            entity.HasKey(e => e.MaMauSac).HasName("PK__MauSac__B9A911624D925E3C");

            entity.ToTable("MauSac");

            entity.Property(e => e.MaMauSac).ValueGeneratedNever();
            entity.Property(e => e.TenMauSac).HasMaxLength(400);
        });

        modelBuilder.Entity<NhanVien>(entity =>
        {
            entity.HasKey(e => e.MaNhanVien).HasName("PK__NhanVien__77B2CA47A13D6790");

            entity.ToTable("NhanVien");

            entity.Property(e => e.MaNhanVien).ValueGeneratedNever();
            entity.Property(e => e.AnhDaiDien).HasMaxLength(400);
            entity.Property(e => e.ChucVu).HasMaxLength(400);
            entity.Property(e => e.DiaChi).HasMaxLength(400);
            entity.Property(e => e.Email).HasMaxLength(400);
            entity.Property(e => e.GhiChu).HasMaxLength(400);
            entity.Property(e => e.NgaySinh).HasColumnType("datetime");
            entity.Property(e => e.SoDienThoai).HasMaxLength(10);
            entity.Property(e => e.TenNhanVien).HasMaxLength(400);

            entity.HasOne(d => d.EmailNavigation).WithMany(p => p.NhanViens)
                .HasForeignKey(d => d.Email)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__NhanVien__Email__46E78A0C");
        });

        modelBuilder.Entity<QuocGium>(entity =>
        {
            entity.HasKey(e => e.MaNuoc).HasName("PK__QuocGia__21306FEABD176696");

            entity.Property(e => e.MaNuoc).ValueGeneratedNever();
            entity.Property(e => e.TenNuoc).HasMaxLength(400);
        });

        modelBuilder.Entity<SanPham>(entity =>
        {
            entity.HasKey(e => e.MaSp).HasName("PK__SanPham__2725081C208C0A4D");

            entity.ToTable("SanPham");

            entity.Property(e => e.MaSp)
                .ValueGeneratedNever()
                .HasColumnName("MaSP");
            entity.Property(e => e.AnhDaiDien).HasMaxLength(400);
            entity.Property(e => e.GiaLonNhat).HasColumnType("money");
            entity.Property(e => e.GiaNhoNhat).HasColumnType("money");
            entity.Property(e => e.GioiThieuSanPham).HasMaxLength(400);
            entity.Property(e => e.MaDt).HasColumnName("MaDT");
            entity.Property(e => e.MaHangSx).HasColumnName("MaHangSX");
            entity.Property(e => e.TenSp)
                .HasMaxLength(400)
                .HasColumnName("TenSP");
            entity.Property(e => e.ThoiGianBaoHanh).HasColumnType("datetime");

            entity.HasOne(d => d.MaChatLieuNavigation).WithMany(p => p.SanPhams)
                .HasForeignKey(d => d.MaChatLieu)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SanPham__MaChatL__4E88ABD4");

            entity.HasOne(d => d.MaDtNavigation).WithMany(p => p.SanPhams)
                .HasForeignKey(d => d.MaDt)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SanPham__MaDT__5070F446");

            entity.HasOne(d => d.MaHangSxNavigation).WithMany(p => p.SanPhams)
                .HasForeignKey(d => d.MaHangSx)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SanPham__MaHangS__5165187F");

            entity.HasOne(d => d.MaLoaiNavigation).WithMany(p => p.SanPhams)
                .HasForeignKey(d => d.MaLoai)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SanPham__MaLoai__4F7CD00D");

            entity.HasOne(d => d.MaNuocNavigation).WithMany(p => p.SanPhams)
                .HasForeignKey(d => d.MaNuoc)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SanPham__MaNuoc__52593CB8");
        });

        modelBuilder.Entity<TrangThaiDonHang>(entity =>
        {
            entity.HasKey(e => e.MaTrangThaiDh).HasName("PK__TrangTha__EB26C7C0F5E48090");

            entity.ToTable("TrangThaiDonHang");

            entity.Property(e => e.MaTrangThaiDh)
                .ValueGeneratedNever()
                .HasColumnName("MaTrangThaiDH");
            entity.Property(e => e.MaHdb).HasColumnName("MaHDB");
            entity.Property(e => e.NgayGiaoHang).HasColumnType("datetime");
            entity.Property(e => e.NgayGiaoThanhCong).HasColumnType("datetime");
            entity.Property(e => e.NgayHuyHon).HasColumnType("datetime");
            entity.Property(e => e.NgayXacNhan).HasColumnType("datetime");

            entity.HasOne(d => d.MaHdbNavigation).WithMany(p => p.TrangThaiDonHangs)
                .HasForeignKey(d => d.MaHdb)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TrangThai__MaHDB__6D0D32F4");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
