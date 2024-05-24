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
  MaPhieuNhap INT primary key IDENTITY,
  NgayNhap DATE NOT NULL,
  MaNhanVien INT NOT NULL,
  FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien),
);

CREATE TABLE ChitietPhieuNhap (
  MaPhieuNhap INT NOT NULL,
  MaHang INT NOT NULL,
  SoLuongNhap INT NOT NULL,
  SoLuongNhapTon INT NOT NULL
  constraint CTPNhap primary key (MaPhieuNhap,MaHang),
  FOREIGN KEY (MaPhieuNhap) REFERENCES PhieuNhap(MaPhieuNhap),
  FOREIGN KEY (MaHang) REFERENCES HangHoa(MaHang)
);

CREATE TABLE PhieuXuat (
  MaPhieuXuat INT primary key IDENTITY,
  NgayXuat DATE NOT NULL,
  MaNhanVien INT NOT NULL,
  FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien)
);

CREATE TABLE ChitietPhieuXuat (
  MaPhieuXuat INT NOT NULL,
  MaHang INT NOT NULL,
  SoLuongXuat INT NOT NULL,
  SoLuongCon INT NOT NULL
  constraint CTPXuat primary key (MaPhieuXuat,MaHang),
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
create proc HangHoa_Select
@MaHang int = 1
as
	Select MaHang,TenHang,LoaiHang,SoLuongTon,TenNhaCungCap, a.MaNhaCungCap
	from [dbo].[HangHoa] a join [dbo].[NhaCungCap] b on a.MaNhaCungCap = b.MaNhaCungCap
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
	where MaHang=5
Go

-- xoá nhà cung cấp
Create proc NhaCungCap_Delete
@MaNhaCungCap int
as
	Delete NhaCungCap
	where MaNhaCungCap=@MaNhaCungCap
Go

-- Phương thức Insert mã phiếu nhập vào bảng phiếu nhập
Create proc PhieuNhap_Insert
@MaPhieuNhap int,
@MaNhanVien int
as
insert into PhieuNhap(NgayNhap, MaNhanVien)
values(GETDATE(), @MaNhanVien)
Go

-- thêm chi tiết phiếu nhập
Create proc ChiTietPhieuNhap_InsertAndUpdate
@MaPhieuNhap int, 
@MaHang int, 
@SoLuongNhap int
as
if Exists (select 1 from chitietPhieuNhap where maphieuNhap=@MaPhieuNhap and MaHang=@MaHang)
begin 
	update chitietphieunhap
	set soluongNhap+=@SoLuongNhap,
		SoLuongNhapTon=soluongNhap
    where maphieuNhap=@MaPhieuNhap and MaHang=@MaHang
end
else
begin 
	insert into ChiTietPhieuNhap(MaPhieuNhap, MaHang,SoLuongNhap,SoLuongNhapTon)
	values(@MaPhieuNhap, @MaHang, @SoLuongNhap, @SoLuongNhap)
end
go

-- hiện thị chi tiết phiếu nhập
create proc ChiTietPhieuNhap_Select
@MaPhieuNhap int
as
SELECT ROW_NUMBER() over (order by (select 1)) as STT, a.MaHang, TenHang,TenNhaCungCap,SoLuongNhap
FROM ChitietPhieuNhap a join HangHoa b on a.MaHang = b.MaHang join NhaCungCap c on b.MaNhaCungCap = c.MaNhaCungCap
where a.MaPhieuNhap=@MaPhieuNhap
go

-- hiện thị phiếu nhập
create proc PhieuNhap_Select
@TuNgay date, 
@DenNgay date
as
select ROW_NUMBER() over (order by (select 1)) as STT ,a.MaPhieuNhap, NgayNhap, a.MaNhanVien,TenNhanVien
from PhieuNhap a  join NhanVien b on b.MaNhanVien=a.MaNhanVien
where NgayNhap between @TuNgay and @DenNgay
group by a.MaPhieuNhap, NgayNhap, a.MaNhanVien,TenNhanVien
go

create proc PhieuNhap_SelectAll
as
select ROW_NUMBER() over (order by (select 1)) as STT ,a.MaPhieuNhap, NgayNhap, a.MaNhanVien,TenNhanVien
from PhieuNhap a  join NhanVien b on b.MaNhanVien=a.MaNhanVien
group by a.MaPhieuNhap, NgayNhap, a.MaNhanVien,TenNhanVien
go

-- Phương thức Insert mã phiếu xuất vào bảng phiếu xuất
Create proc PhieuXuat_Insert
@MaPhieuXuat int,
@MaNhanVien int
as
insert into PhieuXuat(NgayXuat, MaNhanVien)
values(GETDATE(), @MaNhanVien)
Go

-- thêm chi tiết phiếu xuất
Create proc ChiTietPhieuXuat_InsertAndUpdate
@MaPhieuXuat int, 
@MaHang int, 
@SoLuongXuat int
as
if Exists (select 1 from ChitietPhieuXuat where MaPhieuXuat=@MaPhieuXuat and MaHang=@MaHang)
begin 
	update ChitietPhieuXuat
	set soLuongXuat+=@SoLuongXuat,
		SoLuongCon=soluongXuat
    where MaPhieuXuat=@MaPhieuXuat and MaHang=@MaHang
end
else
begin 
	insert into ChitietPhieuXuat(MaPhieuXuat, MaHang,soLuongXuat,SoLuongCon)
	values(@MaPhieuXuat, @MaHang, @SoLuongXuat, @SoLuongXuat)
end
go

-- hiện thị chi tiết phiếu xuất
create proc ChiTietPhieuXuat_Select
@MaPhieuXuat int
as
SELECT ROW_NUMBER() over (order by (select 1)) as STT, a.MaHang, TenHang,TenNhaCungCap,SoLuongXuat
FROM ChitietPhieuXuat a join HangHoa b on a.MaHang = b.MaHang join NhaCungCap c on b.MaNhaCungCap = c.MaNhaCungCap
where a.MaPhieuXuat=@MaPhieuXuat
go

-- hiện thị phiếu xuất
create proc PhieuXuat_Select
@TuNgay date, 
@DenNgay date
as
select ROW_NUMBER() over (order by (select 1)) as STT ,a.MaPhieuXuat, NgayXuat, a.MaNhanVien,TenNhanVien
from PhieuXuat a  join NhanVien b on b.MaNhanVien=a.MaNhanVien
where NgayXuat between @TuNgay and @DenNgay
group by a.MaPhieuXuat, NgayXuat, a.MaNhanVien,TenNhanVien
go

create proc PhieuXuat_SelectAll
as
select ROW_NUMBER() over (order by (select 1)) as STT ,a.MaPhieuXuat, NgayXuat, a.MaNhanVien,TenNhanVien
from PhieuXuat a  join NhanVien b on b.MaNhanVien=a.MaNhanVien
group by a.MaPhieuXuat, NgayXuat, a.MaNhanVien,TenNhanVien
go

-- trigger cập nhật hiện thị số lượng tồn trong chi tiết phiếu nhập
CREATE TRIGGER UpdateSoLuongTon_Insert
ON ChiTietPhieuNhap
AFTER INSERT
AS
BEGIN
    UPDATE HangHoa
    SET SoLuongTon = SoLuongTon + i.SoLuongNhap
    FROM HangHoa hh
    INNER JOIN inserted i ON hh.MaHang = i.MaHang;
END;
Go

-- trigger cập nhật hiện thị số lượng tồn trong chi tiết phiếu nhập sau cập nhật
CREATE TRIGGER UpdateSoLuongTon_Update
ON ChiTietPhieuNhap
AFTER UPDATE
AS
BEGIN
    UPDATE [dbo].[HangHoa]
    SET SoLuongTon = hh.SoLuongTon + (i.SoLuongNhap - d.SoLuongNhap)
    FROM HangHoa hh
    INNER JOIN inserted i ON hh.MaHang = i.MaHang
    INNER JOIN deleted d ON i.MaHang=d.MaHang and i.MaPhieuNhap=d.MaPhieuNhap;
END;
GO

-- trigger cập nhật hiện thị số lượng tồn trong chi tiết phiếu nhập sau khi xoá
CREATE TRIGGER UpdateSoLuongTon_Delete
ON ChiTietPhieuNhap
AFTER DELETE
AS
BEGIN
    UPDATE HangHoa
    SET SoLuongTon = SoLuongTon - d.SoLuongNhap
    FROM HangHoa hh
    INNER JOIN deleted d ON hh.MaHang = d.MaHang;
END;
Go

-- Proc lấy thông tin nhà cung cấp vào cboNhaCungCap - NhapKhoModifies
Create PROC NhaCungCap_SelectToComboBox
AS
SELECT MaNhaCungCap, TenNhaCungCap
FROM dbo.NhaCungCap
Go

-- Proc lấy thông tin HangHoa vào cboMatHang - NhapKhoModifies
create PROC HangHoa_SelectToComboBox @MaNhaCungCap int
AS
SELECT MaHang, TenHang
FROM dbo.HangHoa
WHERE MaNhaCungCap = @MaNhaCungCap
Go

-- Proc lấy MaHang lớn nhất
create PROC PhieuNhap_LayMaxID
AS
SELECT top 1 Max(MaPhieuNhap)+1 as MaPhieuNhap
FROM dbo.PhieuNhap
Go
create PROC PhieuXuat_LayMaxID
AS
SELECT top 1 Max(MaPhieuXuat)+1 as MaPhieuXuat
FROM dbo.PhieuXuat
Go
-- trigger cập nhật hiện thị số lượng tồn trong chi tiết phiếu xuất
CREATE TRIGGER CTPX_UpdateSoLuongTon_Insert
ON ChiTietPhieuXuat
AFTER INSERT
AS
BEGIN
	IF EXISTS (
        SELECT 1
        FROM inserted i
        INNER JOIN HangHoa hh ON i.MaHang = hh.MaHang
        WHERE i.SoLuongXuat > hh.SoLuongTon
    )
    BEGIN
        -- Rollback the transaction if the condition is violated
        ROLLBACK;
        -- Raise an error to inform the user
        RAISERROR ('Cannot insert: SoLuongXuat is greater than SoLuongTon.', 16, 1);
        RETURN;
    END;
    UPDATE HangHoa
    SET SoLuongTon = SoLuongTon - i.SoLuongXuat
    FROM HangHoa hh
    INNER JOIN inserted i ON hh.MaHang = i.MaHang;
END;
Go

-- trigger cập nhật hiện thị số lượng tồn trong chi tiết phiếu xuất sau cập nhật
CREATE TRIGGER CTPX_UpdateSoLuongTon_Update
ON ChiTietPhieuXuat
AFTER UPDATE
AS
BEGIN
	IF EXISTS (
        SELECT 1
        FROM inserted i
        INNER JOIN deleted d ON i.MaHang = d.MaHang AND i.MaPhieuXuat = d.MaPhieuXuat
        INNER JOIN HangHoa hh ON i.MaHang = hh.MaHang
        WHERE hh.SoLuongTon - (i.SoLuongXuat - d.SoLuongXuat) < 0
    )
    BEGIN
        -- Rollback the transaction if the condition is violated
        ROLLBACK;
        -- Raise an error to inform the user
        RAISERROR ('Cannot update: SoLuongXuat results in negative SoLuongTon.', 16, 1);
        RETURN;
    END;
    UPDATE [dbo].[HangHoa]
    SET SoLuongTon = hh.SoLuongTon - (i.SoLuongXuat - d.SoLuongXuat)
    FROM HangHoa hh
    INNER JOIN inserted i ON hh.MaHang = i.MaHang
    INNER JOIN deleted d ON i.MaHang=d.MaHang and i.MaPhieuXuat=d.MaPhieuXuat;
END;
GO

-- trigger cập nhật hiện thị số lượng tồn trong chi tiết phiếu xuất sau khi xoá
CREATE TRIGGER CTPX_UpdateSoLuongTon_Delete
ON ChiTietPhieuXuat
AFTER DELETE
AS
BEGIN
    UPDATE HangHoa
    SET SoLuongTon = SoLuongTon + d.SoLuongXuat
    FROM HangHoa hh
    INNER JOIN deleted d ON hh.MaHang = d.MaHang;
END;
Go

----Thao tác trên bảng CTPX----
Create proc CTPX_Delete
@MaPhieuXuat int,
@MaHang int
as
	Delete ChitietPhieuXuat
	where MaPhieuXuat = @MaPhieuXuat and MaHang = @MaHang
Go

----Thao tác trên bảng CTPN----
Create proc CTPN_Delete
@MaPhieuNhap int,
@MaHang int
as
	Delete ChitietPhieuNhap
	where MaPhieuNhap = @MaPhieuNhap and MaHang = @MaHang
Go