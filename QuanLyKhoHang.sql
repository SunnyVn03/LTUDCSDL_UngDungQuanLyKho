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

insert into NhaCungCap(TenNhaCungCap,DiaChi,DienThoai,Email) values
	(N'Nha A',N'Duong Nguyen Van A','0998877665','a@gmail.com'),
	(N'Nha B',N'Duong Nguyen Van B','0998877663','b@gmail.com'),
	(N'Nha C',N'Duong Nguyen Van C','0998877662','c@gmail.com')

insert into KhachHang(TenKhachHang,DiaChi,DienThoai,Email) values
	(N'Khach A',N'Duong Nguyen Van A','0998877625','ka@gmail.com'),
	(N'Khach B',N'Duong Nguyen Van B','0998876343','kb@gmail.com'),
	(N'Khach C',N'Duong Nguyen Van C','0998877643','kc@gmail.com')

insert into HangHoa(TenHang,LoaiHang,SoLuongTon,MaNhaCungCap) values
	(N'But chi',N'hop','3',1),
	(N'Banh',N'cai','30',1),
	(N'Sach',N'bo','33',2),
	(N'But bi',N'hop','23',3),
	(N'Choi',N'chiec','7',2)
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

-- hiện thị thông tin hàng hoá
Create proc HangHoa_Select
@MaHang int = 1
as
	Select MaHang,TenHang,LoaiHang,SoLuongTon,MaNhaCungCap
	from [dbo].[HangHoa]
	where @MaHang=Case @MaHang when 0 then @MaHang else @MaHang 
end
Go

-- hiện thị thông tin nhà cung cấp
Create proc NhaCungCap_Select
@MaNhaCungCap int = 1
as
	Select MaNhaCungCap,TenNhaCungCap,DiaChi,DienThoai,Email
	from [dbo].[NhaCungCap]
	where @MaNhaCungCap=Case @MaNhaCungCap when 0 then @MaNhaCungCap else @MaNhaCungCap 
end
Go

-- thêm hàng hoá
Create proc HangHoa_InsertAndUpdate
@MaHang int, @TenHang nvarchar(255), @LoaiHang nvarchar(50), @SoLuongTon int, @MaNhaCungCap int
as
if exists (select 1 from HangHoa where MaHang=@MaHang)
begin
	update HangHoa
	set TenHang=@TenHang, LoaiHang=@LoaiHang,SoLuongTon=@SoLuongTon,MaNhaCungCap=@MaNhaCungCap
	where MaHang=@MaHang
end
else
begin
	insert into HangHoa(TenHang,LoaiHang,SoLuongTon,MaNhaCungCap)
	values( @TenHang, @LoaiHang, @SoLuongTon, @MaNhaCungCap)
end
go

-- thêm nhà cung cấp
Create proc NhaCungCap_InsertAndUpdate
@MaNhaCungCap int, @TenNhaCungCap nvarchar(255), @DiaChi nvarchar(255), @DienThoai nvarchar(20), @Email nvarchar(50)
as
if exists (select 1 from NhaCungCap where MaNhaCungCap=@MaNhaCungCap)
begin
	update NhaCungCap
	set TenNhaCungCap=@TenNhaCungCap, DiaChi=@DiaChi,DienThoai=@DienThoai,Email=@Email
	where MaNhaCungCap=@MaNhaCungCap
end
else
begin
	insert into NhaCungCap(TenNhaCungCap,DiaChi,DienThoai,Email)
	values( @TenNhaCungCap, @DiaChi, @DienThoai, @Email)
end
go

-- xoá hàng hoá
Create proc HangHoa_Delete
@MaHang int
as
	Delete HangHoa
	where MaHang=@MaHang
Go

-- xoá nhà cung cấp
Create proc NhaCungCap_Delete
@MaNhaCungCap int
as
	Delete NhaCungCap
	where MaNhaCungCap=@MaNhaCungCap
Go