USE HT_tuyendung
Go

--tài khoản người tìm việc
IF OBJECT_ID('usp_taikhoanNTV', 'P') IS NOT NULL
	DROP PROC usp_taikhoanNTV
GO

CREATE PROC usp_taikhoanNTV
	@Ho nchar(10),
	@Ten nchar(10),
	@Email nvarchar(50),
	@MKhau nvarchar(50),
	@DienThoai nvarchar(20)

AS
	INSERT INTO NguoiTimViec(Ho,Ten,Email, MatKhau, Sdt)
	VALUES (@ho,@ten,@Email, @MKhau, @DienThoai)
	

GO
EXEC usp_taikhoanNTV N'lê',N'Vy',N'levy@gmail.com', N'1234321', N'01234543213'


--tài khoản nhà tuyển dụng
IF OBJECT_ID('usp_taikhoanNTD', 'P') IS NOT NULL
	DROP PROC usp_taikhoanNTD;
GO

CREATE PROC usp_taikhoanNTD
	@Ten nchar(10),
	@Email nvarchar(50),
	@MKhau nvarchar(50),
	@DienThoai nvarchar(20)
AS
	INSERT INTO NhaTuyenDung(Ten_cty,Email, MatKhau, Sdt)
	VALUES (@Ten,@Email, @MKhau, @DienThoai)
GO
EXEC usp_taikhoanNTD N'lê',N'levy@gmail.com', N'1234321', N'01234543213'


-- kiểm tra Email NTV
IF OBJECT_ID ('USP_emailNTV','P') IS NOT NULL
	DROP PROC USP_emailNTV
GO

CREATE PROC USP_emailNTV
	@email NVARCHAR (50)
AS
	Select MA_NTV,Email
	FROM [HT_tuyendung].[dbo].[NguoiTimViec]
	WHERE Email = @email
	--RETURN 1
GO
EXEC USP_emailNTV N'locvy@gmail.com'


