USE HT_tuyendung
--DANG NHAP & xem Nha Tuyen Dung
IF OBJECT_ID('uspDangNhapNTD', 'P') is not null
	DROP PROC uspDangNhapNTD
GO
CREATE PROCEDURE uspDangNhapNTD
@Email nvarchar(50),
@Matkhau nvarchar (50)
as
SELECT * FROM NhaTuyenDung
WHERE Email = @Email and MatKhau = @Matkhau
go
exec uspDangNhapNTD 'hatien@gmail.com', 'hatien'

-- Xoa Nha Tuyen Dung
IF OBJECT_ID('uspXoaNTD', 'P') is not null
	DROP PROC uspXoaNTD
GO
CREATE PROCEDURE uspXoaNTD
@MaNTD int
as
DELETE NhaTuyenDung
WHERE Ma_NTD = @MaNTD
go
exec uspXoaNTD 1

--Sua Nha Tuyen Dung
IF OBJECT_ID('uspSuaNTD', 'P') is not null
	DROP PROC uspSuaNTD
GO
CREATE PROCEDURE uspSuaNTD
@MaNTD int,
@TenCty nvarchar(10),
@Email nvarchar (50),
@Matkhau nvarchar (50),
@SDT nvarchar (50),
@Fax nvarchar (50),
@Diachi nvarchar (50),
@Quymo nvarchar (max),
@Ghichu nvarchar (max)
as
UPDATE NhaTuyenDung
SET Ten_cty= @TenCty, Email = @Email, MatKhau = @Matkhau, SDT = @SDT, Fax = @Fax, DiaChi = @Diachi, QuyMo= @Quymo, GhiChu = @Ghichu
WHERE Ma_NTD = @MaNTD
go
exec uspSuaNTD 2, 'Thang Long', 'thanglong@gmail.com', 'thanglong', '123', '4321', 'BinhThuan', 'l', 'gc'

--Them Nha Tuyen Dung
IF OBJECT_ID('uspThemNTD', 'P') is not null
	DROP PROC uspThemNTD
GO
CREATE PROCEDURE uspThemNTD
--@MaNTD int,
@TenCty nvarchar(10),
@Email nvarchar (50),
@Matkhau nvarchar (50),
@SDT nvarchar (50),
@Fax nvarchar (50),
@Diachi nvarchar (50),
@Quymo nvarchar (max),
@Ghichu nvarchar (max)
as
INSERT INTO NhaTuyenDung(Ten_cty, Email, MatKhau, SDT, Fax, DiaChi, QuyMo, GhiChu)
VALUES (@TenCty, @Email, @Matkhau, @SDT, @Fax, @Diachi, @Quymo, @Ghichu)
go
EXEC uspThemNTD 'Thang Long', 'thanglong@gmail.com', 'thanglong', '123', '4321', 'PhanThiet', 'l', 'gc'