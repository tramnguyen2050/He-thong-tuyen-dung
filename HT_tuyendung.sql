IF OBJECT_ID('HT_tuyendung', 'P')IS NOT NULL
	DROP PROC HT_tuyendung
GO

IF DB_ID('HT_tuyendung') IS NULL 
	CREATE DATABASE HT_tuyendung
GO

USE HT_tuyendung
GO
CREATE TABLE [dbo].[CongViec](
	[Ma_CV] [int] IDENTITY(1,1) NOT NULL,
	[Ten_CV] [nchar](10) NOT NULL,
	[Ma_NN] [nchar](10) NOT NULL,
	[ChucVu] [nvarchar](50) NOT NULL,
	[LoaiCV] [nvarchar](50) NULL,
	[KinhNghiem] [nvarchar](50) NULL,
	[NgonNgu] [nvarchar](50) NULL,
	[MoTa] [nvarchar](max) NULL,
 CONSTRAINT [PK_CongViec] PRIMARY KEY CLUSTERED 
(
	[Ma_CV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

CREATE TABLE [dbo].[HoSoXinViec](
	[Ma_HS] [int] IDENTITY(1,1) NOT NULL,
	[Ten_HS] [nchar](10) NOT NULL,
	[Ma_NTV] [int] NOT NULL,
	[NgayNop] [datetime] NOT NULL,
	[KinhNghiem] [nvarchar](50) NOT NULL,
	[NgoaiNgu] [nvarchar](50) NULL,
	[TrinhDo] [nvarchar](50) NULL,
	[ViTriMongMuon] [nvarchar](50) NULL,
	[GhiChu] [nvarchar](max) NULL,
 CONSTRAINT [PK_HoSoXinViec] PRIMARY KEY CLUSTERED 
(
	[Ma_HS] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO


CREATE TABLE [dbo].[KNVL](
	[Ma_NN] [int] NOT NULL,
	[Ma_KN] [int] IDENTITY(1,1) NOT NULL,
	[GhiChu] [nvarchar](max) NULL,
 CONSTRAINT [PK_NguoiTimViec_KyNang] PRIMARY KEY CLUSTERED 
(
	[Ma_NN] ASC,
	[Ma_KN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO


CREATE TABLE [dbo].[KyNang](
	[Ma_KN] [int] IDENTITY(1,1) NOT NULL,
	[TenKN] [nchar](10) NOT NULL,
	[MoTa] [nvarchar](50) NULL,
	[GhiChu] [nvarchar](max) NULL,
 CONSTRAINT [PK_KyNang] PRIMARY KEY CLUSTERED 
(
	[Ma_KN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO


CREATE TABLE [dbo].[NopHoSo](
	[Ma_NTD] [int] NOT NULL,
	[Ma_HS] [int] IDENTITY(1,1) NOT NULL,
	[NgayNop] [datetime] NOT NULL,
	[GhiChu] [nvarchar](max) NULL,
 CONSTRAINT [PK_NhaTuyenDung_hoSo] PRIMARY KEY CLUSTERED 
(
	[Ma_NTD] ASC,
	[Ma_HS] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

CREATE TABLE [dbo].[NTD_CongViec](
	[Ma_CV] [int] NOT NULL,
	[Ma_NTD] [int] NOT NULL,
	[Mo_ta] [nchar](10) NULL,
 CONSTRAINT [PK_NTD_CongViec] PRIMARY KEY CLUSTERED 
(
	[Ma_CV] ASC,
	[Ma_NTD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


CREATE TABLE [dbo].[NganhNghe](
	[Ma_NN] [int] IDENTITY(1,1) NOT NULL,
	[Ten_NN] [nchar](10) NOT NULL,
	[Ten_CV] [nvarchar](50) NULL,
	[MoTa] [nvarchar](max) NULL,
	[GhiChu] [nvarchar](max) NULL,
 CONSTRAINT [PK_NganhNghe] PRIMARY KEY CLUSTERED 
(
	[Ma_NN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO


CREATE TABLE [dbo].[NganhNgheTuyenDung](
	[Ma_NTD] [int] IDENTITY(1,1) NOT NULL,
	[Ma_NN] [int] NOT NULL,
	[GhiChu] [nvarchar](max) NULL,
 CONSTRAINT [PK_NhaTuyenDung_NganhNghe] PRIMARY KEY CLUSTERED 
(
	[Ma_NTD] ASC,
	[Ma_NN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

CREATE TABLE [dbo].[NguoiTimViec](
	[Ma_NTV] [int] IDENTITY(1,1) NOT NULL,
	[Ho] [nchar](10) NOT NULL,
	[Ten] [nchar](10) NOT NULL,
	[NgaySinh] [datetime] NULL,
	[GioiTinh] [nchar](10) NULL,
	[Email] [nvarchar](50) NOT NULL,
	[MatKhau] [nvarchar](50) NULL,
	[Sdt] [nvarchar](20) NULL,
	[DiaChi] [nvarchar](50) NULL,
	[GhiChu] [nvarchar](max) NULL,
 CONSTRAINT [PK_NguoiTimViec] PRIMARY KEY CLUSTERED 
(
	[Ma_NTV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO


CREATE TABLE [dbo].[NhaTuyenDung](
	[Ma_NTD] [int] IDENTITY(1,1) NOT NULL,
	[Ten_cty] [nchar](10) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[MatKhau] [nvarchar](50) NULL,
	[SDT] [nvarchar](50) NULL,
	[Fax] [nvarchar](50) NULL,
	[DiaChi] [nvarchar](50) NULL,
	[QuyMo] [nvarchar](max) NULL,
	[GhiChu] [nvarchar](max) NULL,
 CONSTRAINT [PK_NhaTuyenDung] PRIMARY KEY CLUSTERED 
(
	[Ma_NTD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[CongViec]  WITH CHECK ADD  CONSTRAINT [FK_CongViec_CongViec] FOREIGN KEY([Ma_CV])
REFERENCES [dbo].[CongViec] ([Ma_CV])
GO
ALTER TABLE [dbo].[CongViec] CHECK CONSTRAINT [FK_CongViec_CongViec]
GO
ALTER TABLE [dbo].[HoSoXinViec]  WITH CHECK ADD  CONSTRAINT [FK_HoSoXinViec_NguoiTimViec] FOREIGN KEY([Ma_NTV])
REFERENCES [dbo].[NguoiTimViec] ([Ma_NTV])
GO
ALTER TABLE [dbo].[HoSoXinViec] CHECK CONSTRAINT [FK_HoSoXinViec_NguoiTimViec]
GO
ALTER TABLE [dbo].[KNVL]  WITH CHECK ADD  CONSTRAINT [FK_KNVL_KyNang] FOREIGN KEY([Ma_KN])
REFERENCES [dbo].[KyNang] ([Ma_KN])
GO
ALTER TABLE [dbo].[KNVL] CHECK CONSTRAINT [FK_KNVL_KyNang]
GO
ALTER TABLE [dbo].[KNVL]  WITH CHECK ADD  CONSTRAINT [FK_KNVL_NganhNghe] FOREIGN KEY([Ma_NN])
REFERENCES [dbo].[NganhNghe] ([Ma_NN])
GO
ALTER TABLE [dbo].[KNVL] CHECK CONSTRAINT [FK_KNVL_NganhNghe]
GO
ALTER TABLE [dbo].[NopHoSo]  WITH CHECK ADD  CONSTRAINT [FK_NopHoSo_HoSoXinViec] FOREIGN KEY([Ma_HS])
REFERENCES [dbo].[HoSoXinViec] ([Ma_HS])
GO
ALTER TABLE [dbo].[NopHoSo] CHECK CONSTRAINT [FK_NopHoSo_HoSoXinViec]
GO
ALTER TABLE [dbo].[NopHoSo]  WITH CHECK ADD  CONSTRAINT [FK_NopHoSo_NhaTuyenDung] FOREIGN KEY([Ma_NTD])
REFERENCES [dbo].[NhaTuyenDung] ([Ma_NTD])
GO
ALTER TABLE [dbo].[NopHoSo] CHECK CONSTRAINT [FK_NopHoSo_NhaTuyenDung]
GO
ALTER TABLE [dbo].[NTD_CongViec]  WITH CHECK ADD  CONSTRAINT [FK_NTD_CongViec_CongViec] FOREIGN KEY([Ma_CV])
REFERENCES [dbo].[CongViec] ([Ma_CV])
GO
ALTER TABLE [dbo].[NTD_CongViec] CHECK CONSTRAINT [FK_NTD_CongViec_CongViec]
GO
ALTER TABLE [dbo].[NTD_CongViec]  WITH CHECK ADD  CONSTRAINT [FK_NTD_CongViec_NhaTuyenDung] FOREIGN KEY([Ma_NTD])
REFERENCES [dbo].[NhaTuyenDung] ([Ma_NTD])
GO
ALTER TABLE [dbo].[NTD_CongViec] CHECK CONSTRAINT [FK_NTD_CongViec_NhaTuyenDung]
GO
ALTER TABLE [dbo].[NganhNgheTuyenDung]  WITH CHECK ADD  CONSTRAINT [FK_NganhNgheTuyenDung_NganhNghe] FOREIGN KEY([Ma_NN])
REFERENCES [dbo].[NganhNghe] ([Ma_NN])
GO
ALTER TABLE [dbo].[NganhNgheTuyenDung] CHECK CONSTRAINT [FK_NganhNgheTuyenDung_NganhNghe]
GO

ALTER TABLE [dbo].[NganhNgheTuyenDung]  WITH CHECK ADD  CONSTRAINT [FK_NganhNgheTuyenDung_NhaTuyenDung] FOREIGN KEY([Ma_NTD])
REFERENCES [dbo].[NhaTuyenDung] ([Ma_NTD])
GO
ALTER TABLE [dbo].[NganhNgheTuyenDung] CHECK CONSTRAINT [FK_NganhNgheTuyenDung_NhaTuyenDung]
GO
USE [master]
GO
ALTER DATABASE [HT_tuyendung] SET  READ_WRITE 
GO
