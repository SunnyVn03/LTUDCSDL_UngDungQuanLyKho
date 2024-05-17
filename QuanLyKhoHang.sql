create database QuanLyKhoHang
go
use QuanLyKhoHang
go
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE NhaCungCap (
  MaNhaCungCap INT IDENTITY PRIMARY KEY,
  TenNhaCungCap VARCHAR(255) NOT NULL,
  DiaChi VARCHAR(255) NOT NULL,
  DienThoai VARCHAR(20) NOT NULL,
  Email VARCHAR(50)
);

CREATE TABLE KhachHang (
  MaKhachHang INT PRIMARY KEY IDENTITY,
  TenKhachHang VARCHAR(255) NOT NULL,
  DiaChi VARCHAR(255) NOT NULL,
  DienThoai VARCHAR(20) NOT NULL,
  Email VARCHAR(50)
);

CREATE TABLE NhanVien (
  MaNhanVien INT PRIMARY KEY IDENTITY,
  TenNhanVien VARCHAR(255) NOT NULL,
  TaiKhoan VARCHAR(20) NOT NULL,
  MatKhau VARBINARY(max) NOT NULL
);

CREATE TABLE HangHoa (
  MaHang INT PRIMARY KEY IDENTITY,
  TenHang VARCHAR(255) NOT NULL,
  LoaiHang VARCHAR(50) NOT NULL,
  SoLuongTon INT NOT NULL,
  MaNhaCungCap INT NOT NULL,
  FOREIGN KEY (MaNhaCungCap) REFERENCES NhaCungCap(MaNhaCungCap)
);

CREATE TABLE PhieuNhap (
  MaPhieuNhap INT PRIMARY KEY IDENTITY,
  NgayNhap DATE NOT NULL,
  MaNhaCungCap INT NOT NULL,
  MaNhanVien INT NOT NULL,
  FOREIGN KEY (MaNhaCungCap) REFERENCES NhaCungCap(MaNhaCungCap),
  FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien)
);

CREATE TABLE ChitietPhieuNhap (
  MaCTPN INT PRIMARY KEY IDENTITY, -- mã chi tiết phiếu nhập
  MaPhieuNhap INT NOT NULL,
  MaHang INT NOT NULL,
  SoLuongNhap INT NOT NULL,
  FOREIGN KEY (MaPhieuNhap) REFERENCES PhieuNhap(MaPhieuNhap),
  FOREIGN KEY (MaHang) REFERENCES HangHoa(MaHang)
);

CREATE TABLE PhieuXuat (
  MaPhieuXuat INT PRIMARY KEY IDENTITY,
  NgayXuat DATE NOT NULL,
  MaKhachHang INT NOT NULL,
  MaNhanVien INT NOT NULL,
  FOREIGN KEY (MaKhachHang) REFERENCES KhachHang(MaKhachHang),
  FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien)
);

CREATE TABLE ChitietPhieuXuat (
  MaCTPX INT PRIMARY KEY IDENTITY,  -- mã chi tiết phiếu xuất
  MaPhieuXuat INT NOT NULL,
  MaHang INT NOT NULL,
  SoLuongXuat INT NOT NULL,
  FOREIGN KEY (MaPhieuXuat) REFERENCES PhieuXuat(MaPhieuXuat),
  FOREIGN KEY (MaHang) REFERENCES HangHoa(MaHang)
);
go

-- nhập dữ liệu vào data
Insert into NhanVien(TenNhanVien,TaiKhoan,MatKhau) values
	(N'Nguyen Van A','admin',PWDENCRYPT('123456')),
	(N'Nguyen Van A','user',PWDENCRYPT('123456')),
	(N'Nguyen Van A','user1',PWDENCRYPT('123456'))
go

-- kiểm tra đăng nhập
create proc KiemTraDangNhap
@TaiKhoan varchar(50),
@MatKhau varchar(50)
as
if exists (select 1 from NhanVien where TaiKhoan=@TaiKhoan and PWDCOMPARE(@MatKhau,MatKhau)=1)
begin 
	select 1 as Code,MaNhanVien,TenNhanVien
	from NhanVien
	where TaiKhoan=@TaiKhoan and PWDCOMPARE(@MatKhau,MatKhau)=1
end
else
begin 
	select 0 as Code,'' as MaNhanVien,N'' as TenNhanVien
End
Go
