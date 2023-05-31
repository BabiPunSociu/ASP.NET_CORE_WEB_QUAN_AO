CREATE DATABASE [CuaHangBanQuanAo]
USE [CuaHangBanQuanAo]
GO

CREATE TABLE ChatLieu
(
  MaChatLieu INT NOT NULL,
  ChatLieu NVARCHAR(400) NOT NULL,
  PRIMARY KEY (MaChatLieu)
);

CREATE TABLE LoaiSP
(
  MaLoai INT NOT NULL,
  Loai NVARCHAR(400) NOT NULL,
  PRIMARY KEY (MaLoai)
);

CREATE TABLE LoaiDacTinh
(
  MaDT INT NOT NULL,
  TenDT NVARCHAR(400) NOT NULL,
  PRIMARY KEY (MaDT)
);

CREATE TABLE HangSX
(
  MaHangSX INT NOT NULL,
  TenHangSX NVARCHAR(400) NOT NULL,
  SLDaBan INT NULL,
  PRIMARY KEY (MaHangSX)
);

CREATE TABLE QuocGia
(
  MaNuoc INT NOT NULL,
  TenNuoc NVARCHAR(400) NOT NULL,
  PRIMARY KEY (MaNuoc)
);

CREATE TABLE MauSac
(
  MaMauSac INT NOT NULL,
  TenMauSac NVARCHAR(400) NOT NULL,
  PRIMARY KEY (MaMauSac)
);

CREATE TABLE KichThuoc
(
  MaKichThuoc INT NOT NULL,
  KichThuoc NVARCHAR(400) NOT NULL,
  PRIMARY KEY (MaKichThuoc)
);

CREATE TABLE Account
(
  Email NVARCHAR(400) NOT NULL,
  [password] NVARCHAR(400) NOT NULL,
  LoaiUser NVARCHAR(400) NULL,
  PRIMARY KEY (Email)
);

CREATE TABLE NhanVien
(
  MaNhanVien INT NOT NULL,
  TenNhanVien NVARCHAR(400) NOT NULL,
  NgaySinh DATETIME NULL,
  SoDienThoai NVARCHAR(10) NULL,
  DiaChi NVARCHAR(400) NULL,
  ChucVu NVARCHAR(400) NULL,
  AnhDaiDien NVARCHAR(400) NULL,
  GhiChu NVARCHAR(400) NULL,
  Email NVARCHAR(400) NOT NULL,
  PRIMARY KEY (MaNhanVien),
  FOREIGN KEY (Email) REFERENCES Account(Email)
);

CREATE TABLE KhuyenMai
(
  MaKM INT NOT NULL,
  TenKM NVARCHAR(400) NOT NULL,
  NgayBD DATETIME NOT NULL,
  NgayKT DATETIME NOT NULL,
  TinhTrang BIT NOT NULL,
  GiaTri MONEY NOT NULL,
  ChiTiet NVARCHAR(400) NULL,
  PRIMARY KEY (MaKM)
);

CREATE TABLE HoaDonNhap
(
  MaHDN INT NOT NULL,
  NgayNhap DATETIME NOT NULL,
  TongTienHD MONEY NULL,
  MaSoThue NVARCHAR(400) NULL,
  ThongTinThue NVARCHAR(400) NULL,
  PhuongThucThanhToan NVARCHAR(400) NOT NULL,
  GhiChu NVARCHAR(400) NULL,
  MaNhanVien INT NOT NULL,
  PRIMARY KEY (MaHDN),
  FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien)
);
GO

CREATE TABLE SanPham
(
  MaSP INT NOT NULL,
  TenSP NVARCHAR(400) NOT NULL,
  ThoiGianBaoHanh DATETIME NULL,
  GioiThieuSanPham NVARCHAR(400) NULL,
  ChietKhau FLOAT NULL,
  AnhDaiDien NVARCHAR(400) NULL,
  GiaLonNhat MONEY NULL,
  GiaNhoNhat MONEY NULL,
  MaChatLieu INT NOT NULL,
  MaLoai INT NOT NULL,
  MaDT INT NOT NULL,
  MaHangSX INT NOT NULL,
  MaNuoc INT NOT NULL,
  BestSeller BIT NOT NULL,
  ConHang BIT NOT NULL,
  PRIMARY KEY (MaSP),
  FOREIGN KEY (MaChatLieu) REFERENCES ChatLieu(MaChatLieu),
  FOREIGN KEY (MaLoai) REFERENCES LoaiSP(MaLoai),
  FOREIGN KEY (MaDT) REFERENCES LoaiDacTinh(MaDT),
  FOREIGN KEY (MaHangSX) REFERENCES HangSX(MaHangSX),
  FOREIGN KEY (MaNuoc) REFERENCES QuocGia(MaNuoc)
);

CREATE TABLE ChiTietSanPham
(
  MaChiTietSanPham INT NOT NULL,
  AnhDaiDien NVARCHAR(400) NULL,
  Video NVARCHAR(400) NULL,
  DonGiaBan MONEY NOT NULL,
  DonGiaNhap MONEY NOT NULL,
  SLTon INT NOT NULL,
  MaSP INT NOT NULL,
  MaMauSac INT NOT NULL,
  MaKichThuoc INT NOT NULL,
  MaKM INT NULL,
  PRIMARY KEY (MaChiTietSanPham),
  FOREIGN KEY (MaSP) REFERENCES SanPham(MaSP),
  FOREIGN KEY (MaMauSac) REFERENCES MauSac(MaMauSac),
  FOREIGN KEY (MaKichThuoc) REFERENCES KichThuoc(MaKichThuoc),
  FOREIGN KEY (MaKM) REFERENCES KhuyenMai(MaKM)
);

CREATE TABLE KhachHang
(
  MaKhachHang INT NOT NULL,
  TenKhachHang NVARCHAR(400) NOT NULL,
  NgaySinh DATETIME NULL,
  SoDienThoai NVARCHAR(10)  NULL,
  DiaChi NVARCHAR(400)  NULL,
  LoaiKhachHang NVARCHAR(400) NULL,
  AnhDaiDien NVARCHAR(400) NULL,
  GhiChu NVARCHAR(400) NULL,
  Email NVARCHAR(400) NOT NULL,
  PRIMARY KEY (MaKhachHang),
  FOREIGN KEY (Email) REFERENCES Account(Email)
);

CREATE TABLE ChiTietHDN
(
  SoLuongNhap INT NOT NULL,
  DonGiaNhap MONEY NOT NULL,
  GhiChu NVARCHAR(400) NULL,
  MaChiTietSanPham INT NOT NULL,
  MaHDN INT NOT NULL,
  PRIMARY KEY (MaChiTietSanPham, MaHDN),
  FOREIGN KEY (MaChiTietSanPham) REFERENCES ChiTietSanPham(MaChiTietSanPham),
  FOREIGN KEY (MaHDN) REFERENCES HoaDonNhap(MaHDN)
);

CREATE TABLE GioHang
(
  SoLuong INT NOT NULL,
  TrangThai BIT NULL,
  MaChiTietSanPham INT NOT NULL,
  MaKhachHang INT NOT NULL,
  PRIMARY KEY (MaChiTietSanPham, MaKhachHang),
  FOREIGN KEY (MaChiTietSanPham) REFERENCES ChiTietSanPham(MaChiTietSanPham),
  FOREIGN KEY (MaKhachHang) REFERENCES KhachHang(MaKhachHang)
);

CREATE TABLE AnhSP
(
  TenFileAnh NVARCHAR(400) NOT NULL,
  Vitri NVARCHAR(400) NULL,
  MaSP INT NOT NULL,
  PRIMARY KEY (TenFileAnh),
  FOREIGN KEY (MaSP) REFERENCES SanPham(MaSP)
);

CREATE TABLE HoaDonBan
(
  MaHDB INT NOT NULL,
  NgayBan DATETIME NOT NULL,
  TongTienHD MONEY NULL,
  PhuongThucThanhToan NVARCHAR(400) NOT NULL,
  MaSoThue NVARCHAR(400) NULL,
  ThongTinThue NVARCHAR(400) NULL,
  GhiChu NVARCHAR(400) NULL,
  NgayDatHang DATETIME NOT NULL,
  MaKhachHang INT NOT NULL,
  MaNhanVien INT NOT NULL,
  MaKM INT NULL,
  PRIMARY KEY (MaHDB),
  FOREIGN KEY (MaKhachHang) REFERENCES KhachHang(MaKhachHang),
  FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien),
  FOREIGN KEY (MaKM) REFERENCES KhuyenMai(MaKM)
);

CREATE TABLE TrangThaiDonHang
(
  MaTrangThaiDH INT NOT NULL,
  DaXacNhan BIT NOT NULL,
  NgayXacNhan DATETIME NULL,
  DangGiaHang BIT NOT NULL,
  NgayGiaoHang DATETIME NULL,
  DaGiaoThanhCong BIT NOT NULL,
  NgayGiaoThanhCong DATETIME NULL,
  HuyDon BIT NOT NULL,
  NgayHuyHon DATETIME NULL,
  MaHDB INT NOT NULL,
  PRIMARY KEY (MaTrangThaiDH),
  FOREIGN KEY (MaHDB) REFERENCES HoaDonBan(MaHDB)
);

CREATE TABLE ChiTietHDB
(
  SoLuongBan INT NOT NULL,
  DonGiaBan MONEY NOT NULL,
  GhiChu NVARCHAR(400) NULL,
  MaHDB INT NOT NULL,
  MaChiTietSanPham INT NOT NULL,
  PRIMARY KEY (MaHDB, MaChiTietSanPham),
  FOREIGN KEY (MaHDB) REFERENCES HoaDonBan(MaHDB),
  FOREIGN KEY (MaChiTietSanPham) REFERENCES ChiTietSanPham(MaChiTietSanPham)
);

--------------------------------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------------------

-- Insert ChatLieu --
INSERT INTO ChatLieu(MaChatLieu, ChatLieu)
VALUES
(1, N'Da'),
(2, N'Lụa'),
(3, N'Vải Cotton'),
(4, N'Vải polyeste'),
(5, N'Vải Linen (vải lanh)'),
(6, N'Vải Lycra'),
(7, N'Vải Rayon'),
(8, N'Lông cừu'),
(9, N'Vải Modal'),
(10, N'Vải Tencel')
GO

-- Insert LoaiSP --
INSERT INTO LoaiSP(MaLoai, Loai)
VALUES
(1, N'Bộ đồ'),
(2, N'Áo'),
(3, N'Quần'),
(4, N'Váy'),
(5, N'Đầm')
GO

-- Insert QUocGia --
INSERT INTO QuocGia(MaNuoc, TenNuoc)
VALUES
(1, N'Việt Nam'),
(2, N'Pháp'),
(3, N'Nhập Bản'),
(4, N'Milan'),
(5, N'Anh Quốc'),
(6, N'Italya'),
(7, N'Trung Quốc')
GO
-- Insert HangSX --
INSERT INTO HangSX(MaHangSX, TenHangSX)
VALUES
(1, N'Chanel'), --Pháp
(2, N'Hermes'), --Pháp
(3, N'Gucci'), -- Ý -> Pháp
(4, N'Louis Vuitton'), --Pháp
(5, N'Prada'), -- Milan
(6, N'Dior'), -- Pháp
(7, N'Burberry'), -- Anh
(8, N'Dolce & Gabbana'), -- Ý
(9, N'Uniqlo'), -- Nhật bản
(10, N'Canifa') -- VN
GO
-- Insert LoaiDacTinh --
INSERT INTO LoaiDacTinh(MaDT, TenDT)
VALUES
(1, N'Văn phòng'),
(2, N'Sexy'),
(3, N'Du lịch'),
(4, N'Năng động'),
(5, N'Trẻ trung'),
(6, N'Lịch sự'),
(7, N'Trang trọng'),
(8, N'Đơn giản')
GO

-- Insert SanPham --
INSERT INTO SanPham(MaSP, TenSP, ThoiGianBaoHanh, GioiThieuSanPham, ChietKhau, AnhDaiDien, GiaLonNhat, GiaNhoNhat, MaChatLieu, MaLoai, MaDT, MaHangSX, MaNuoc, BestSeller, ConHang)
VALUES
(1, N'Áo Thun Tay Ngắn Dáng Ôm Hở Xương Quai Xanh Phong Cách Hong Kong Thời Trang', null,
N'Một chiếc áo tuyệt xinh để các thiên thần tự tin khoe cá tính', null, N'sp1.jpg', 500000, 200000, 1, 1, 1, 1, 1, 1, 1),
(2, N'Áo Thun polo Ngắn Tay Dáng Rộng Phong Cách Hàn Quốc Thời Trang Mùa Hè', null,
N'Một chiếc áo tuyệt xinh để các thiên thần tự tin khoe cá tính', null, N'sp2.jpg', 450000, 150000, 2, 2, 2, 2, 2, 1, 1),
(3, N'Jumpsuit Denim Hai Dây Họa Tiết Hoa Phong Cách Mới Mùa Hè', null,
N'Một chiếc áo tuyệt xinh để các thiên thần tự tin khoe cá tính', null, N'sp3.jpg', 40000, 150000, 3, 3, 3, 3, 3, 1, 1),
(4, N'Bộ Jumpsuit nữ cổ sơ mi liền, quần jean tôn dáng, set demin jean nữ tôn dáng, quần áo nữ thời trang, hàng thiết kế', null,
N'Một chiếc áo tuyệt xinh để các thiên thần tự tin khoe cá tính', null, N'sp4.jpg', 600000, 500000, 4, 4, 4, 4, 4, 1, 1),
(5, N'Bộ Jumpsuit Hai Dây Dáng Rộng Lưng Cao Thời Trang', null,
N'Một chiếc áo tuyệt xinh để các thiên thần tự tin khoe cá tính', null, N'sp5.jpg', 146000, 200000, 5, 5, 5, 5, 5, 0, 1),
(6, N'Quần ống suông dài nỉ nhung tăm to độc đáo, quần ống rộng', null,
N'Một chiếc quần tuyệt xinh để các thiên thần tự tin khoe cá tính', null, N'sp6.png', 450000, 150000, 6, 1, 6, 6, 6, 0, 1),
(7, N'Quần jean ngố nữ rách cạnh sườn lưng cao, vải jean denim không co dãn bền đẹp', null,
N'Một chiếc áo tuyệt xinh để các thiên thần tự tin khoe cá tính', null, N'sp7.jpg', 450000, 150000, 7, 2, 7, 7, 7, 0, 1),
(8, N'Đầm thiết kế, váy caro ôm xốp cup ngực dây đai buộc eo xinh xắn', null,
N'Một chiếc áo tuyệt xinh để các thiên thần tự tin khoe cá tính', null, N'sp8.jpg', 450000, 150000, 8, 3, 8, 8, 1, 0, 1),
(9, N'váy đen sẻ tà dự tiệc sang chảnh-hàng cao cấp loại 1-đầm maxi sẻ tà du lịch biển mùa hè siêu xinh', null,
N'Một chiếc áo tuyệt xinh để các thiên thần tự tin khoe cá tính', null, N'sp9.jpg', 450000, 150000, 9, 4, 1, 9, 2, 0, 1),
(10, N'Đầm công sở CITI MODE FASHION thiết kế dáng xoè hồng peplum phối cổ thêu hoa', null,
N'Một chiếc áo tuyệt xinh để các thiên thần tự tin khoe cá tính', null, N'sp10.jpg', 450000, 150000, 10, 5, 2, 10, 3, 0, 1)
GO
-- Insert AnhSP --
INSERT INTO AnhSP(TenFileAnh, Vitri, MaSP)
VALUES
-- sp1
(N'anhsp1-1.jpg', null, 1),
(N'anhsp1-2.jpg', null, 1),
(N'anhsp1-3.jpg', null, 1),
(N'anhsp1-4.jpg', null, 1),
(N'anhsp1-5.jpg', null, 1),
(N'anhsp1-6.jpg', null, 1),
(N'anhsp1-7.jpg', null, 1),
(N'anhsp1-8.jpg', null, 1),
(N'anhsp1-9.jpg', null, 1),
-- sp2
(N'anhsp2-1.jpg', null, 2),
(N'anhsp2-2.jpg', null, 2),
(N'anhsp2-3.jpg', null, 2),
(N'anhsp2-4.jpg', null, 2),
(N'anhsp2-5.jpg', null, 2),
(N'anhsp2-6.jpg', null, 2),
(N'anhsp2-7.jpg', null, 2),
(N'anhsp2-8.jpg', null, 2),
-- sp3
(N'anhsp3-1.jpg', null, 3),
(N'anhsp3-2.jpg', null, 3),
(N'anhsp3-3.jpg', null, 3),
(N'anhsp3-4.jpg', null, 3),
(N'anhsp3-5.jpg', null, 3),
(N'anhsp3-6.jpg', null, 3),
(N'anhsp3-7.jpg', null, 3),
-- sp4
(N'anhsp4-1.jpg', null, 4),
(N'anhsp4-2.jpg', null, 4),
(N'anhsp4-3.jpg', null, 4),
(N'anhsp4-4.jpg', null, 4),
(N'anhsp4-5.jpg', null, 4),
(N'anhsp4-6.jpg', null, 4),
-- sp5
(N'anhsp5-1.jpg', null, 5),
(N'anhsp5-2.jpg', null, 5),
(N'anhsp5-3.jpg', null, 5),
(N'anhsp5-4.jpg', null, 5),
(N'anhsp5-5.jpg', null, 5),
(N'anhsp5-6.jpg', null, 5),
(N'anhsp5-7.jpg', null, 5),
(N'anhsp5-8.jpg', null, 5),
--sp6
(N'anhsp6-1.jpg', null, 6),
(N'anhsp6-2.jpg', null, 6),
(N'anhsp6-3.jpg', null, 6),
(N'anhsp6-4.jpg', null, 6),
(N'anhsp6-5.jpg', null, 6),
(N'anhsp6-6.jpg', null, 6),
--sp7
(N'anhsp7-1.jpg', null, 7),
(N'anhsp7-2.jpg', null, 7),
(N'anhsp7-3.jpg', null, 7),
(N'anhsp7-4.jpg', null, 7),
(N'anhsp7-5.jpg', null, 7),
(N'anhsp7-6.jpg', null, 7),
(N'anhsp7-7.jpg', null, 7),
(N'anhsp7-8.jpg', null, 7),
--sp8
(N'anhsp8-1.jpg', null, 8),
(N'anhsp8-2.jpg', null, 8),
(N'anhsp8-3.jpg', null, 8),
(N'anhsp8-4.jpg', null, 8),
(N'anhsp8-5.jpg', null, 8),
(N'anhsp8-6.jpg', null, 8),
(N'anhsp8-7.jpg', null, 8),
(N'anhsp8-8.jpg', null, 8),
--sp9
(N'anhsp9-1.jpg', null, 9),
(N'anhsp9-2.jpg', null, 9),
(N'anhsp9-3.jpg', null, 9),
(N'anhsp9-4.jpg', null, 9),
(N'anhsp9-5.jpg', null, 9),
(N'anhsp9-6.jpg', null, 9),
(N'anhsp9-7.jpg', null, 9),
(N'anhsp9-8.jpg', null, 9),
--sp10
(N'anhsp10-1.jpg', null, 10),
(N'anhsp10-2.jpg', null, 10),
(N'anhsp10-3.jpg', null, 10),
(N'anhsp10-4.jpg', null, 10),
(N'anhsp10-5.jpg', null, 10),
(N'anhsp10-6.jpg', null, 10)
GO
-- Insert MauSac --
INSERT INTO MauSac(MaMauSac, TenMauSac)
VALUES
(1, N'Đen'),
(2, N'Trắng'),
(3, N'Đỏ'),
(4, N'Xanh'),
(5, N'Xám')
GO

-- Insert KichThuoc --
INSERT INTO KichThuoc(MaKichThuoc, KichThuoc)
VALUES
(1, N'S'),
(2, N'M'),
(3, N'L'),
(4, N'XL'),
(5, N'XXL')
GO

-- Insert KhuyenMai ---
INSERT INTO KhuyenMai(MaKM, TenKM, NgayBD, NgayKT, ChiTiet, GiaTri, TinhTrang)
VALUES
(1, N'HAPPY', N'2023-4-30', N'2023-5-2', N'Giảm 20% cho tất cả các đơn hàng', 0.20, 1),
(2, N'BLACK-FRIDAY', N'2023-4-1', N'2023-6-1', N'Giảm 10% cho toàn bộ sản phẩm trong cửa hàng', 0.1, 1)
GO

-- Insert ChiTietSanPham ---
INSERT INTO ChiTietSanPham(MaChiTietSanPham, AnhDaiDien, Video, DonGiaBan, DonGiaNhap, SLTon, MaSP, MaMauSac, MaKichThuoc, MaKM)
VALUES
-- sp1, 5 màu, kích thước s
(1, N'anhsp1-1.jpg', null, 300000, 200000, 50, 1, 1, 1, null),
(2, N'anhsp1-1.jpg', null, 300000, 200000, 50, 1, 2, 1, null),
(3, N'anhsp1-1.jpg', null, 300000, 200000, 50, 1, 3, 1, null),
(4, N'anhsp1-1.jpg', null, 300000, 200000, 50, 1, 4, 1, null),
(5, N'anhsp1-1.jpg', null, 300000, 200000, 50, 1, 5, 1, null),
-- sp1, 5 màu, kích thước M
(6, N'anhsp1-2.jpg', null, 300000, 200000, 50, 1, 1, 2, null),
(7, N'anhsp1-2.jpg', null, 300000, 200000, 50, 1, 2, 2, null),
(8, N'anhsp1-2.jpg', null, 300000, 200000, 50, 1, 3, 2, null),
(9, N'anhsp1-2.jpg', null, 300000, 200000, 50, 1, 4, 2, null),
(10, N'anhsp1-2.jpg', null, 300000, 200000, 50, 1, 5, 2, null),
-- sp1, 5 màu, kích thước L
(11, N'anhsp1-3.jpg', null, 300000, 200000, 50, 1, 1, 3, null),
(12, N'anhsp1-3.jpg', null, 300000, 200000, 50, 1, 2, 3, null),
(13, N'anhsp1-3.jpg', null, 300000, 200000, 50, 1, 3, 3, null),
(14, N'anhsp1-3.jpg', null, 300000, 200000, 50, 1, 4, 3, null),
(15, N'anhsp1-3.jpg', null, 300000, 200000, 50, 1, 5, 3, null),
-- sp1, 5 màu, kích thước XL
(16, N'anhsp1-4.jpg', null, 300000, 200000, 50, 1, 1, 4, null),
(17, N'anhsp1-4.jpg', null, 300000, 200000, 50, 1, 2, 4, null),
(18, N'anhsp1-4.jpg', null, 300000, 200000, 50, 1, 3, 4, null),
(19, N'anhsp1-4.jpg', null, 300000, 200000, 50, 1, 4, 4, null),
(20, N'anhsp1-4.jpg', null, 300000, 200000, 50, 1, 5, 4, null),
-- sp1, 5 màu, kích thước XL
(21, N'anhsp1-5.jpg', null, 300000, 200000, 50, 1, 1, 5, null),
(22, N'anhsp1-5.jpg', null, 300000, 200000, 50, 1, 2, 5, null),
(23, N'anhsp1-5.jpg', null, 300000, 200000, 50, 1, 3, 5, null),
(24, N'anhsp1-5.jpg', null, 300000, 200000, 50, 1, 4, 5, null),
(25, N'anhsp1-5.jpg', null, 300000, 200000, 50, 1, 5, 5, null),
--------------------------------------------------------------
-- sp2, 5 màu, kích thước s
(26, N'anhsp2-1.jpg', null, 300000, 200000, 50, 1, 1, 1, null),
(27, N'anhsp2-1.jpg', null, 300000, 200000, 50, 1, 2, 1, null),
(28, N'anhsp2-1.jpg', null, 300000, 200000, 50, 1, 3, 1, null),
(29, N'anhsp2-1.jpg', null, 300000, 200000, 50, 1, 4, 1, null),
(30, N'anhsp2-1.jpg', null, 300000, 200000, 50, 1, 5, 1, null),
-- sp2, 5 màu, kích thước M
(31, N'anhsp2-2.jpg', null, 300000, 200000, 50, 1, 1, 2, null),
(32, N'anhsp2-2.jpg', null, 300000, 200000, 50, 1, 2, 2, null),
(33, N'anhsp2-2.jpg', null, 300000, 200000, 50, 1, 3, 2, null),
(34, N'anhsp2-2.jpg', null, 300000, 200000, 50, 1, 4, 2, null),
(35, N'anhsp2-2.jpg', null, 300000, 200000, 50, 1, 5, 2, null),
-- sp2, 5 màu, kích thước L
(36, N'anhsp2-3.jpg', null, 300000, 200000, 50, 1, 1, 3, null),
(37, N'anhsp2-3.jpg', null, 300000, 200000, 50, 1, 2, 3, null),
(38, N'anhsp2-3.jpg', null, 300000, 200000, 50, 1, 3, 3, null),
(39, N'anhsp2-3.jpg', null, 300000, 200000, 50, 1, 4, 3, null),
(40, N'anhsp2-3.jpg', null, 300000, 200000, 50, 1, 5, 3, null),
-- sp2, 5 màu, kích thước XL
(41, N'anhsp2-4.jpg', null, 300000, 200000, 50, 1, 1, 4, null),
(42, N'anhsp2-4.jpg', null, 300000, 200000, 50, 1, 2, 4, null),
(43, N'anhsp2-4.jpg', null, 300000, 200000, 50, 1, 3, 4, null),
(44, N'anhsp2-4.jpg', null, 300000, 200000, 50, 1, 4, 4, null),
(45, N'anhsp2-4.jpg', null, 300000, 200000, 50, 1, 5, 4, null),
-- sp2, 5 màu, kích thước XL
(46, N'anhsp2-5.jpg', null, 300000, 200000, 50, 1, 1, 5, null),
(47, N'anhsp2-5.jpg', null, 300000, 200000, 50, 1, 2, 5, null),
(48, N'anhsp2-5.jpg', null, 300000, 200000, 50, 1, 3, 5, null),
(49, N'anhsp2-5.jpg', null, 300000, 200000, 50, 1, 4, 5, null),
(50, N'anhsp2-5.jpg', null, 300000, 200000, 50, 1, 5, 5, null),
--------------------------------------------------------------
-- sp3, 5 màu, kích thước s
(51, N'anhsp3-1.jpg', null, 300000, 200000, 50, 1, 1, 1, null),
(52, N'anhsp3-1.jpg', null, 300000, 200000, 50, 1, 2, 1, null),
(53, N'anhsp3-1.jpg', null, 300000, 200000, 50, 1, 3, 1, null),
(54, N'anhsp3-1.jpg', null, 300000, 200000, 50, 1, 4, 1, null),
(55, N'anhsp3-1.jpg', null, 300000, 200000, 50, 1, 5, 1, null),
-- sp3, 5 màu, kích thước M
(56, N'anhsp3-2.jpg', null, 300000, 200000, 50, 1, 1, 2, null),
(57, N'anhsp3-2.jpg', null, 300000, 200000, 50, 1, 2, 2, null),
(58, N'anhsp3-2.jpg', null, 300000, 200000, 50, 1, 3, 2, null),
(59, N'anhsp3-2.jpg', null, 300000, 200000, 50, 1, 4, 2, null),
(60, N'anhsp3-2.jpg', null, 300000, 200000, 50, 1, 5, 2, null),
-- sp3, 5 màu, kích thước L
(61, N'anhsp3-3.jpg', null, 300000, 200000, 50, 1, 1, 3, null),
(62, N'anhsp3-3.jpg', null, 300000, 200000, 50, 1, 2, 3, null),
(63, N'anhsp3-3.jpg', null, 300000, 200000, 50, 1, 3, 3, null),
(64, N'anhsp3-3.jpg', null, 300000, 200000, 50, 1, 4, 3, null),
(65, N'anhsp3-3.jpg', null, 300000, 200000, 50, 1, 5, 3, null),
-- sp3, 5 màu, kích thước XL
(66, N'anhsp3-4.jpg', null, 300000, 200000, 50, 1, 1, 4, null),
(67, N'anhsp3-4.jpg', null, 300000, 200000, 50, 1, 2, 4, null),
(68, N'anhsp3-4.jpg', null, 300000, 200000, 50, 1, 3, 4, null),
(69, N'anhsp3-4.jpg', null, 300000, 200000, 50, 1, 4, 4, null),
(70, N'anhsp3-4.jpg', null, 300000, 200000, 50, 1, 5, 4, null),
-- sp3, 5 màu, kích thước XL
(71, N'anhsp3-5.jpg', null, 300000, 200000, 50, 1, 1, 5, null),
(72, N'anhsp3-5.jpg', null, 300000, 200000, 50, 1, 2, 5, null),
(73, N'anhsp3-5.jpg', null, 300000, 200000, 50, 1, 3, 5, null),
(74, N'anhsp3-5.jpg', null, 300000, 200000, 50, 1, 4, 5, null),
(75, N'anhsp3-5.jpg', null, 300000, 200000, 50, 1, 5, 5, null)
--------------------------------------------------------------
GO
-- Insert Account ---
INSERT INTO Account(Email, [password], LoaiUser)
VALUES
(N'Dung@gmail.com', N'123456', null), -- User
(N'Admin@gmail.com', N'123456', null) -- Admin
GO


-- Insert KhachHang----
INSERT INTO KhachHang(MaKhachHang, TenKhachHang, NgaySinh, SoDienThoai,
	DiaChi, LoaiKhachHang, AnhDaiDien, GhiChu, Email)
VALUES
(1, N'Dũng Nguyễn', N'2000-10-28', N'0971821742', N'Hà Nội, Việt Nam',
null, N'avatar_default.jpg', null, N'Dung@gmail.com')
GO


-- Insert NHanVien ----
INSERT INTO NhanVien(MaNhanVien, TenNhanVien, NgaySinh, SoDienThoai, DiaChi,
	ChucVu, AnhDaiDien, GhiChu, Email)
VALUES
(1, N'BabiPunSociu', N'2000-10-28', N'0971821742', N'Hà Nội, Việt Nam',
N'Admin', N'avatar_default.jpg', null, N'Dung@gmail.com')
GO
-- Insert HoaDonBan ----


-- Insert TrangThaiDonHang ---


-- Insert HoaDonNhap ---


-- ChiTietHDB ----


-- HoaDonNhap ---


-- GioHang -----

------------------------------------------------------------------------------------------------------------------------------------
-- TRIGGER
-- 1. Cập nhật thuộc tính ConHang của SanPham khi Thêm, Sửa, Xóa ChiTietSanPham
CREATE TRIGGER CapNhatConHang ON dbo.ChiTietSanPham
AFTER INSERT, DELETE, UPDATE
AS
BEGIN
	DECLARE @masp INT, @sl INT
	-- Lấy MaSP
	SELECT @masp=MaSP, @sl=SLTon FROM inserted
	IF (@sl!=0)
		BEGIN
			UPDATE SanPham SET ConHang=1 WHERE SanPham.MaSP=@masp
		END
    else
		Begin
			UPDATE SanPham
			SET ConHang = CASE WHEN EXISTS (SELECT 1 FROM ChiTietSanPham WHERE MaSP = @masp AND SLTon > 0) THEN 1 ELSE 0 END
		End
END
GO
-- 2. Cập nhật thuộc tính SLDaBan của HangSX mỗi khi thêm, sửa, xóa ChiTietHDB
CREATE TRIGGER CapNhatSLDaBan ON ChiTietHDB
AFTER INSERT, DELETE, UPDATE
AS
BEGIN
	DECLARE @maHangSX int, @maHDB int, @sl_moi int, @sl_cu int, @sl_daban_cu int
	-- Lấy mã HDB, sl_mới,, sl_cũ
	SELECT @maHDB=inserted.MaHDB, @sl_moi= inserted.SoLuongBan, @sl_cu=deleted.SoLuongBan
	FROM inserted JOIN deleted ON inserted.MaHDB=deleted.MaHDB

	-- Tìm Mã HangSX, SLTon
	SELECT @maHangSX = HangSX.MaHangSX, @sl_daban_cu=SLDaBan
	FROM HangSX JOIN SanPham ON HangSX.MaHangSX=SanPham.MaHangSX
		JOIN ChiTietSanPham ON SanPham.MaSP=ChiTietSanPham.MaSP
		JOIN ChiTietHDB ON ChiTietSanPham.MaChiTietSanPham=ChiTietHDB.MaChiTietSanPham
	WHERE MaHDB=@maHDB

	-- Update
	UPDATE HangSX
	SET SLDaBan = @sl_daban_cu + @sl_cu - @sl_moi
	WHERE MaHangSX=@maHangSX
END
GO

--3. Cập nhật bestSeller trong SanPham mỗi khi thêm, sửa, xóa ChiTietHDB
CREATE TRIGGER CapNhatBestSeller ON ChiTietHDB
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
	-- Update tất cả sản phẩm có bestSeller thành false
	Update SanPham
	SET BestSeller=0 WHERE MaSP IN (SELECT MaSP FROM SanPham WHERE BestSeller=1)

	DECLARE @BestSeller TABLE (MaSP INT)
	-- Tính tổng sl đã bán của các sản phẩm trong 2 tháng gần đây => top(10) là bestSeller đưa vào bảng @BestSeller
	INSERT INTO @BestSeller
	SELECT TOP(10) SanPham.MaSP
	FROM SanPham JOIN ChiTietSanPham ON SanPham.MaSP=ChiTietSanPham.MaSP
		JOIN ChiTietHDB ON ChiTietHDB.MaChiTietSanPham=ChiTietSanPham.MaChiTietSanPham
		JOIN HoaDonBan ON HoaDonBan.MaHDB=ChiTietHDB.MaHDB
	WHERE SanPham.ConHang=1 AND (NgayBan BETWEEN DATEADD(MONTH, -2, GETDATE()) AND GETDATE())
	GROUP BY SanPham.MaSP
	ORDER BY SUM(SoLuongBan)

	-- UPDATE:
	-- Nếu truy vấn không có kết quả, nghĩa là chưa có đủ 10 sản phẩm được bán thì thêm các sản phẩm khác thành bestSeller để đủ 10
	IF ((SELECT COUNT(*) FROM @BestSeller) < 10)
	BEGIN
		INSERT INTO @BestSeller
		SELECT TOP(10-(SELECT COUNT(*) FROM @BestSeller)) MaSP
		FROM SanPham
		WHERE MaSP NOT IN (SELECT MaSP FROM @BestSeller)
	END
	-- Cập nhật các sản phẩm trong danh sách bestSeller
	UPDATE SanPham
	SET BestSeller=1
	WHERE MaSP IN (SELECT MaSP FROM @BestSeller)
END

