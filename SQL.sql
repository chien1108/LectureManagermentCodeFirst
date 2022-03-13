USE [QuanLyGiangVien]
GO
/****** Object:  StoredProcedure [dbo].[GiaoVien_NCKH]    Script Date: 3/10/2022 12:34:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GiaoVien_NCKH]
		@magv varchar(50)
		
AS
	select gvnckh.MaGV ,gvnckh.TenDeTai, gvnckh.Cap, gvnckh.GhiChu, gvnckh.NamThamGiaNC, gvnckh.MaDeTai
	from GiaoVien gv, GiaoVienNCKH gvnckh
	where gvnckh.MaGV=gv.MaGV 
	group by  gvnckh.MaGV, gvnckh.MaDeTai,gvnckh.TenDeTai, gvnckh.Cap, gvnckh.GhiChu, gvnckh.NamThamGiaNC
	
	RETURN
GO
/****** Object:  StoredProcedure [dbo].[GiaoVien_NCKH_CapBo]    Script Date: 3/10/2022 12:34:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[GiaoVien_NCKH_CapBo]
		@magv varchar(50),
		@namNC varchar(30)
AS
	select gvnckh.MaGV ,gvnckh.TenDeTai, gvnckh.Cap, gvnckh.GhiChu, gvnckh.NamThamGiaNC, gvnckh.MaDeTai,gvnckh.NamThamGiaNC 
	from GiaoVien gv, GiaoVienNCKH gvnckh
	where gvnckh.MaGV=gv.MaGV and gvnckh.Cap like N'%Cấp bộ%' and gvnckh.Magv=@magv and gvnckh.NamThamGiaNC=@namNC
	group by  gvnckh.MaGV, gvnckh.MaDeTai,gvnckh.TenDeTai, gvnckh.Cap, gvnckh.GhiChu, gvnckh.NamThamGiaNC
	
	RETURN
GO
/****** Object:  StoredProcedure [dbo].[GiaoVien_NCKH_CapTruong]    Script Date: 3/10/2022 12:34:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROCEDURE [dbo].[GiaoVien_NCKH_CapTruong]
		@magv varchar(50),
		@namNC varchar(30)
AS
	select gvnckh.MaGV ,gvnckh.TenDeTai, gvnckh.Cap, gvnckh.GhiChu, gvnckh.NamThamGiaNC, gvnckh.MaDeTai, gvnckh.NamThamGiaNC
	from GiaoVien gv, GiaoVienNCKH gvnckh 
	where gvnckh.MaGV=gv.MaGV and gvnckh.Cap like N'%Cấp trường%' and gvnckh.Magv=@magv and gvnckh.NamThamGiaNC=@namNC
	group by  gvnckh.MaGV, gvnckh.MaDeTai,gvnckh.TenDeTai, gvnckh.Cap, gvnckh.GhiChu, gvnckh.NamThamGiaNC
	
	RETURN
GO
/****** Object:  StoredProcedure [dbo].[LayTTDeSua]    Script Date: 3/10/2022 12:34:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROCEDURE [dbo].[LayTTDeSua]
@ma int

AS
Select nc.Ma,nc.MaGV,nc.NamHoc,nc.GhiChu from HocBSNangCao nc,GiaoVien gv where  nc.Ma=@ma
RETURN
GO
/****** Object:  StoredProcedure [dbo].[LoadDoAnTotNghiep]    Script Date: 3/10/2022 12:34:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LoadDoAnTotNghiep]
	@maGV varchar(50),
	@namHoc varchar(50)
	
AS
	Select da.Ma, da.MaLop,l.TenLop,da.MaGV,da.GhiChu,da.SoBuoiChamBai,da.SoDeTai,da.SoDoAnPBien,da.NamHoc,gv.MaGV,gv.TenGV,l.MaLop,l.TenLop  
	from GiaoVien gv, DoAnTotNghiep da,Lop l
	 where da.MaGV=@maGV and da.NamHoc=@namHoc and gv.MaGV=da.MaGV and l.MaLop=da.MaLop
	group by da.Ma, da.MaLop,da.MaGV,da.GhiChu,da.SoBuoiChamBai,da.SoDeTai,da.SoDoAnPBien,da.NamHoc,gv.MaGV,gv.TenGV,l.MaLop,l.TenLop 
	RETURN
GO
/****** Object:  StoredProcedure [dbo].[LoadDoAnTotNghiep1]    Script Date: 3/10/2022 12:34:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LoadDoAnTotNghiep1]
	@maGV varchar(50)
AS
	Select da.Ma, da.MaLop,l.TenLop,da.MaGV,da.GhiChu,da.SoBuoiChamBai,da.SoDeTai,da.SoDoAnPBien,da.NamHoc,gv.MaGV,gv.TenGV,l.MaLop,l.TenLop  
	from GiaoVien gv, DoAnTotNghiep da,Lop l where da.MaGV=@maGV  and gv.MaGV=da.MaGV and l.MaLop=da.MaLop
	group by da.Ma, da.MaLop,da.MaGV,da.GhiChu,da.SoBuoiChamBai,da.SoDeTai,da.SoDoAnPBien,da.NamHoc,gv.MaGV,gv.TenGV,l.MaLop,l.TenLop 
	RETURN
GO
/****** Object:  StoredProcedure [dbo].[LoadHocNangCao]    Script Date: 3/10/2022 12:34:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LoadHocNangCao]
@maGV varchar(50)
AS
Select nc.Ma,nc.MaGV,nc.NamHoc,nc.GhiChu,gv.TenGV from HocBSNangCao nc,GiaoVien gv where nc.MaGV=@maGV and nc.MaGV=gv.MaGV
group by nc.Ma,nc.MaGV,nc.GhiChu,nc.NamHoc,gv.TenGV
RETURN
GO
/****** Object:  StoredProcedure [dbo].[LoadMonLyThuyet]    Script Date: 3/10/2022 12:34:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LoadMonLyThuyet]
 @malop varchar(50)
AS

BEGIN
SELECT mh.MaMon,mh.MaHeDT, mh.TenMon, l.MaHeDT, l.MaLop
 FROM MonHoc mh, Lop l WHERE mh.MaLoai='LM01' and l.MaHeDT=mh.MaHeDT and l.MaLop=@malop

END
GO
/****** Object:  StoredProcedure [dbo].[LoadMonProject]    Script Date: 3/10/2022 12:34:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LoadMonProject]
 @malop varchar(50)
AS

BEGIN
SELECT mh.MaMon,mh.MaHeDT, mh.TenMon, l.MaHeDT, l.MaLop
 FROM MonHoc mh, Lop l WHERE mh.MaLoai='LM03' and l.MaHeDT=mh.MaHeDT and l.MaLop=@malop

END
GO
/****** Object:  StoredProcedure [dbo].[LoadMonThucHanh]    Script Date: 3/10/2022 12:34:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROCEDURE [dbo].[LoadMonThucHanh]
@malop varchar(50)
AS
BEGIN
SELECT mh.MaMon,mh.MaHeDT, mh.TenMon, l.MaHeDT, l.MaLop
 FROM MonHoc mh, Lop l WHERE mh.MaLoai='LM02' and l.MaHeDT=mh.MaHeDT and l.MaLop=@malop


END
GO
/****** Object:  StoredProcedure [dbo].[LoadMonTTSP]    Script Date: 3/10/2022 12:34:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[LoadMonTTSP]
@malop varchar(50)
AS
BEGIN
SELECT mh.MaMon,mh.MaHeDT, mh.TenMon, l.MaHeDT, l.MaLop
 FROM MonHoc mh, Lop l WHERE mh.MaLoai='LM05' and l.MaHeDT=mh.MaHeDT and l.MaLop=@malop

END
GO
/****** Object:  StoredProcedure [dbo].[LoadMonTTXN]    Script Date: 3/10/2022 12:34:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[LoadMonTTXN]
@malop varchar(50)
AS
BEGIN
SELECT mh.MaMon,mh.MaHeDT, mh.TenMon, l.MaHeDT, l.MaLop
 FROM MonHoc mh, Lop l WHERE mh.MaLoai='LM04' and l.MaHeDT=mh.MaHeDT and l.MaLop=@malop

END
GO
/****** Object:  StoredProcedure [dbo].[Project]    Script Date: 3/10/2022 12:34:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
	CREATE PROCEDURE [dbo].[Project]
	@magv varchar(50),
	@namHoc varchar(50)
AS
	select mh.TenMon,mh.SoTiet,l.TenLop,l.SiSo, mh.MaLoai, lm.TenLoai, gd.SoSV
from GiangDay gd, Lop l, MonHoc mh, GiaoVien gv, HeDaoTao hdt, LoaiMon lm
where gd.MaGV=gv.MaGV and gd.MaLop=l.MaLop and gd.NamHoc=@namHoc and gd.MaMon=mh.MaMon and hdt.MaHDT=mh.MaHeDT and hdt.MaHDT=l.MaHeDT and gv.MaGV=@magv  and lm.MaLoai=mh.MaLoai
 and mh.MaLoai like N'LM03'
group by  gd.MaGV,l.HinhThucDT,gv.TenGV, l.TenLop, l.SiSo,  mh.SoTiet, mh.MaHeDT,hdt.TenHeDT, mh.MaMon, mh.TenMon,mh.MaLoai, lm.TenLoai,gd.SoSV
	RETURN
GO
/****** Object:  StoredProcedure [dbo].[st_HDNCKH_NamCuoi]    Script Date: 3/10/2022 12:34:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROCEDURE [dbo].[st_HDNCKH_NamCuoi]
		@magv varchar(50),
		@namHoc varchar(50)
AS
	select hdnckh.MaGV , hdnckh.SVNam, hdnckh.SoLuong, hdnckh.NamHoc, hdnckh.GhiChu
	from GiaoVien gv, HuongDanNCKH hdnckh
	where hdnckh.MaGV=gv.MaGV and hdnckh.NamHoc=@namHoc  and hdnckh.MaGV=@magv and hdnckh.SVNam like N'%Năm cuối%'
	group by hdnckh.MaGV ,hdnckh.NamHoc, hdnckh.SVNam, hdnckh.SoLuong,  hdnckh.GhiChu
	
	RETURN
GO
/****** Object:  StoredProcedure [dbo].[st_HDNCKH_NamGanCuoi]    Script Date: 3/10/2022 12:34:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[st_HDNCKH_NamGanCuoi]
		@magv varchar(50),
		@namHoc varchar(50)
AS
	select hdnckh.MaGV , hdnckh.SVNam, hdnckh.SoLuong, hdnckh.NamHoc, hdnckh.GhiChu
	from GiaoVien gv, HuongDanNCKH hdnckh
	where hdnckh.MaGV=gv.MaGV and hdnckh.NamHoc=@namHoc and hdnckh.MaGV=@magv and hdnckh.SVNam like N'%Khác (1, 2, 3)%'
	group by hdnckh.MaGV ,hdnckh.NamHoc, hdnckh.SVNam, hdnckh.SoLuong,  hdnckh.GhiChu
	
	RETURN
GO
/****** Object:  StoredProcedure [dbo].[st_LayLopDTNienChe]    Script Date: 3/10/2022 12:34:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[st_LayLopDTNienChe]
	@magv varchar(50),
	@namHoc varchar(50)
AS
	select mh.TenMon,mh.SoTiet,l.TenLop,l.SiSo, mh.MaLoai, lm.TenLoai, gd.SoSV,gd.SoSV
from GiangDay gd, Lop l, MonHoc mh, GiaoVien gv, HeDaoTao hdt, LoaiMon lm
where gd.MaGV=gv.MaGV and gd.MaLop=l.MaLop and gd.NamHoc=@namHoc and gd.MaMon=mh.MaMon and hdt.MaHDT=mh.MaHeDT and hdt.MaHDT=l.MaHeDT and gv.MaGV=@magv  and lm.MaLoai=mh.MaLoai
and l.HinhThucDT like N'%Niên chế%' and mh.MaLoai like N'LM01' and (mh.MaHeDT like N'HDT10' or mh.MaHeDT like N'HDT4' or  mh.MaHeDT like N'HDT8' )
group by  gd.MaGV,l.HinhThucDT,gv.TenGV, l.TenLop, l.SiSo,  mh.SoTiet, mh.MaHeDT,hdt.TenHeDT, mh.MaMon, mh.TenMon,mh.MaLoai, lm.TenLoai,gd.SoSV,gd.SoSV
	RETURN
GO
/****** Object:  StoredProcedure [dbo].[st_LayLopDTNienCheDHCD]    Script Date: 3/10/2022 12:34:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[st_LayLopDTNienCheDHCD]
@magv varchar(50),
@namHoc varchar(50)
AS
	select mh.TenMon,mh.SoTiet,l.TenLop,l.SiSo, mh.MaLoai, lm.TenLoai,gd.SoSV
from GiangDay gd, Lop l, MonHoc mh, GiaoVien gv, HeDaoTao hdt, LoaiMon lm
where gd.MaGV=gv.MaGV and gd.MaLop=l.MaLop and gd.NamHoc=@namHoc and gd.MaMon=mh.MaMon and hdt.MaHDT=mh.MaHeDT and hdt.MaHDT=l.MaHeDT and gv.MaGV=@magv  and lm.MaLoai=mh.MaLoai
and l.HinhThucDT like N'%Niên chế%' and mh.MaLoai like N'LM01'   and (mh.MaHeDT like N'HDT01' or mh.MaHeDT like N'HDT2'  or mh.MaHeDT like N'HDT3' or mh.MaHeDT like N'HDT5' or mh.MaHeDT like N'HDT6' or mh.MaHeDT like N'HDT7' or mh.MaHeDT like N'HDT9')
group by  gd.MaGV,l.HinhThucDT,gv.TenGV, l.TenLop, l.SiSo,  mh.SoTiet, mh.MaHeDT,hdt.TenHeDT, mh.MaMon, mh.TenMon,mh.MaLoai, lm.TenLoai,gd.SoSV
	RETURN
GO
/****** Object:  StoredProcedure [dbo].[st_LayLopDTTinChi]    Script Date: 3/10/2022 12:34:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[st_LayLopDTTinChi]
@magv varchar(50)
AS
	select mh.TenMon,mh.SoTiet,l.TenLop,l.SiSo, mh.MaLoai, lm.TenLoai,gd.SoSV
from GiangDay gd, Lop l, MonHoc mh, GiaoVien gv, HeDaoTao hdt, LoaiMon lm
where gd.MaGV=gv.MaGV and gd.MaLop=l.MaLop and gd.MaMon=mh.MaMon and hdt.MaHDT=mh.MaHeDT and hdt.MaHDT=l.MaHeDT and gv.MaGV=@magv  and lm.MaLoai=mh.MaLoai
and l.HinhThucDT like N'%Tín chỉ%' and mh.MaLoai like N'LM01'
group by  gd.MaGV,l.HinhThucDT,gv.TenGV, l.TenLop, l.SiSo,  mh.SoTiet, mh.MaHeDT,hdt.TenHeDT, mh.MaMon, mh.TenMon,mh.MaLoai, lm.TenLoai,gd.SoSV
	RETURN
GO
/****** Object:  StoredProcedure [dbo].[st_LayLopDTTinChiDHCD]    Script Date: 3/10/2022 12:34:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[st_LayLopDTTinChiDHCD]
	@magv varchar(50),
	@namHoc varchar(50)
AS
	select mh.TenMon,mh.SoTiet,l.TenLop,l.SiSo, mh.MaLoai, lm.TenLoai, gd.SoSV,gd.SoSV
from GiangDay gd, Lop l, MonHoc mh, GiaoVien gv, HeDaoTao hdt, LoaiMon lm
where gd.MaGV=gv.MaGV and gd.MaLop=l.MaLop and gd.NamHoc=@namHoc and gd.MaMon=mh.MaMon and hdt.MaHDT=mh.MaHeDT and hdt.MaHDT=l.MaHeDT and gv.MaGV=@magv  and lm.MaLoai=mh.MaLoai
and l.HinhThucDT like N'%Tín chỉ%' and mh.MaLoai like N'LM01' and (mh.MaHeDT like N'HDT01' or mh.MaHeDT like N'HDT2'  or mh.MaHeDT like N'HDT3' or mh.MaHeDT like N'HDT5' or mh.MaHeDT like N'HDT6' or mh.MaHeDT like N'HDT7'   or mh.MaHeDT like N'HDT9')
group by  gd.MaGV,l.HinhThucDT,gv.TenGV, l.TenLop, l.SiSo,  mh.SoTiet, mh.MaHeDT,hdt.TenHeDT, mh.MaMon, mh.TenMon,mh.MaLoai, lm.TenLoai,gd.SoSV,gd.SoSV
	RETURN
GO
/****** Object:  StoredProcedure [dbo].[st_LayLopLyThuyet]    Script Date: 3/10/2022 12:34:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[st_LayLopLyThuyet]
	/*
	(
	@parameter1 int = 5,
	@parameter2 datatype OUTPUT
	)
	*/
AS
	select l.MaLop, l.TenLop, l.SiSo from Lop l where   l.MaLop not in (select MaLop from Lop where MaLop like '%.%')

	RETURN
GO
/****** Object:  StoredProcedure [dbo].[st_LayLopTHTCCN]    Script Date: 3/10/2022 12:34:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[st_LayLopTHTCCN]
	@magv varchar(50),
	@namHoc varchar(50)
AS
	select mh.TenMon,mh.SoTiet,l.TenLop,l.SiSo, mh.MaLoai, lm.TenLoai, gd.SoSV,gd.SoSV
from GiangDay gd, Lop l, MonHoc mh, GiaoVien gv, HeDaoTao hdt, LoaiMon lm
where gd.MaGV=gv.MaGV and gd.MaLop=l.MaLop and gd.NamHoc=@namHoc and gd.MaMon=mh.MaMon and hdt.MaHDT=mh.MaHeDT and hdt.MaHDT=l.MaHeDT and gv.MaGV=@magv  and lm.MaLoai=mh.MaLoai
and l.HinhThucDT like N'%Niên chế%' and mh.MaLoai like N'LM02' and (mh.MaHeDT like N'HDT10' or mh.MaHeDT like N'HDT4' or mh.MaHeDT like N'HDT8'  )
group by  gd.MaGV,l.HinhThucDT,gv.TenGV, l.TenLop, l.SiSo,  mh.SoTiet, mh.MaHeDT,hdt.TenHeDT, mh.MaMon, mh.TenMon,mh.MaLoai, lm.TenLoai,gd.SoSV,gd.SoSV
	RETURN
GO
/****** Object:  StoredProcedure [dbo].[st_LayLopThucHanhGV]    Script Date: 3/10/2022 12:34:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[st_LayLopThucHanhGV]
@magv varchar(50),
@namHoc varchar(50)
AS
select mh.TenMon,mh.SoTiet,l.TenLop,l.SiSo, mh.MaLoai, lm.TenLoai,hdt.SoBuoiTren1DVHocTrinh,hdt.MaHDT, gd.SoSV
from GiangDay gd, Lop l, MonHoc mh, GiaoVien gv, HeDaoTao hdt, LoaiMon lm
where gd.MaGV=gv.MaGV and gd.MaLop=l.MaLop and gd.NamHoc=@namHoc and gd.MaMon=mh.MaMon and hdt.MaHDT=mh.MaHeDT and hdt.MaHDT=l.MaHeDT and gv.MaGV=@magv  and lm.MaLoai=mh.MaLoai and mh.MaLoai like N'LM02'
 and (mh.MaHeDT like N'HDT01' or mh.MaHeDT like N'HDT2'  or mh.MaHeDT like N'HDT3' or mh.MaHeDT like N'HDT5' or mh.MaHeDT like N'HDT6' or mh.MaHeDT like N'HDT7'   or mh.MaHeDT like N'HDT9')
group by   gd.MaGV,l.HinhThucDT,gv.TenGV, l.TenLop, l.SiSo,  mh.SoTiet, mh.MaHeDT,hdt.TenHeDT, mh.MaMon, mh.TenMon,mh.MaLoai, lm.TenLoai,hdt.SoBuoiTren1DVHocTrinh,hdt.MaHDT,gd.SoSV
RETURN
GO
/****** Object:  StoredProcedure [dbo].[st_LayMaLopLT]    Script Date: 3/10/2022 12:34:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[st_LayMaLopLT]
AS
	select l.MaLop, l.MaHeDT,l.TenLop from Lop l where   l.MaLop not in (select MaLop from Lop where MaLop like '%.%')
	RETURN
GO
/****** Object:  StoredProcedure [dbo].[st_LayMaLopThucHanh]    Script Date: 3/10/2022 12:34:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[st_LayMaLopThucHanh]
	
AS
	select MaLop, MaHeDT from Lop where MaLop like '%.%'
	RETURN
GO
/****** Object:  StoredProcedure [dbo].[st_LayNamHoc]    Script Date: 3/10/2022 12:34:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROCEDURE [dbo].[st_LayNamHoc]
@magv varchar(50)
AS
	select NamHoc from HocBSNangCao where MaGV=@magv
	RETURN

GO
/****** Object:  StoredProcedure [dbo].[st_LayThanhvien]    Script Date: 3/10/2022 12:34:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[st_LayThanhvien]
	
AS

	select gv.MaGV, gv.TenGV  from GiaoVien gv where gv.MaGV not in 
(select tk.MaGV from TaiKhoan tk)
GO
/****** Object:  StoredProcedure [dbo].[st_LoadGiangVienChucVu]    Script Date: 3/10/2022 12:34:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[st_LoadGiangVienChucVu]
@maGV varchar(50)
as
select gv.MaGV,gv.TenGV,gv.MaChucVu,cv.MaChucVu,cv.PhanTramDuocGiam,cv.TenChucVu,gc.MaChucDanh,gc.SoGioChuan from GiaoVien gv,ChucVu cv,GioChuan gc
where gv.MaGV=@maGV and gv.MaChucVu=cv.MaChucVu and gv.MaChucDanh=gc.MaChucDanh
group by gv.MaGV,gv.TenGV,gv.MaChucVu,cv.MaChucVu,cv.PhanTramDuocGiam,cv.TenChucVu,gc.MaChucDanh,gc.SoGioChuan 
return
GO
/****** Object:  StoredProcedure [dbo].[st_LoadQuanLyPhongMay]    Script Date: 3/10/2022 12:34:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[st_LoadQuanLyPhongMay]
@maGV varchar(50),
@namHoc varchar(50)
as
select ql.* from QLPhongMay ql where ql.MaGV=@maGV and ql.NamHoc=@namHoc
 return
GO
/****** Object:  StoredProcedure [dbo].[st_QuenMatKhau]    Script Date: 3/10/2022 12:34:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[st_QuenMatKhau]
	@tenDN nvarchar(50), @Email nvarchar(100)
AS
BEGIN
	select ac.tendangnhap, ac.matkhau, te.email
	from TaiKhoan ac, GiaoVien te
	where ac.MaGV=te.MaGV and  ac.TenDangNhap=@tenDN and  te.Email=@Email
END
GO
/****** Object:  StoredProcedure [dbo].[st_SuPham]    Script Date: 3/10/2022 12:34:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE 	PROCEDURE [dbo].[st_SuPham]
	@magv varchar(50),
	@namHoc varchar(50)
AS
	select mh.TenMon,mh.SoTiet,l.TenLop,l.SiSo, mh.MaLoai, lm.TenLoai, gd.SoSV
from GiangDay gd, Lop l, MonHoc mh, GiaoVien gv, HeDaoTao hdt, LoaiMon lm
where gd.MaGV=gv.MaGV and gd.MaLop=l.MaLop and gd.NamHoc=@namHoc and gd.MaMon=mh.MaMon and hdt.MaHDT=mh.MaHeDT and hdt.MaHDT=l.MaHeDT and gv.MaGV=@magv  and lm.MaLoai=mh.MaLoai
 and mh.MaLoai like N'LM05'
group by  gd.MaGV,l.HinhThucDT,gv.TenGV, l.TenLop, l.SiSo,  mh.SoTiet, mh.MaHeDT,hdt.TenHeDT, mh.MaMon, mh.TenMon,mh.MaLoai, lm.TenLoai,gd.SoSV
	RETURN

GO
/****** Object:  StoredProcedure [dbo].[st_Thongtincanhan]    Script Date: 3/10/2022 12:34:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[st_Thongtincanhan]
@tendangnhap varchar(50)
AS
/*declare	@username nvarchar(100),
 @fullname nvarchar(100),
 @birthday datetime,
@mail nvarchar(150),
 @gender nvarchar(20),
 @IdentityCard nvarchar(30),
 @Address nvarchar(300),
 @PhoneNumber nvarchar(20),
@RegistrationDate datetime,
 @Decendalization nvarchar(50),
 @Status nvarchar(20)*/
begin 

select tk.magv, tk.tendangnhap,
 gv.tengv,gv.gioitinh,gv.ngaysinh, gv.socmtnd, gv.trinhdohocvan, gv.machucdanh, gv.machucvu, gv.namvaolam,gv.email,gv.diachi, gv.ghichu,
 gc.machucdanh,gc.tenchucdanh,
 cv.machucvu, cv.tenchucvu, bm.mabomon, bm.tenbomon
 from taikhoan  tk, giaovien gv , giochuan gc, chucvu cv, bomon bm
  where tk.magv=gv.magv 
  and gc.machucdanh=gv.machucdanh
  and gv.machucvu=cv.machucvu
 and tk.tendangnhap=@tendangnhap
 and gv.mabomon=bm.mabomon
end
return
GO
/****** Object:  StoredProcedure [dbo].[st_TTxiNghiep]    Script Date: 3/10/2022 12:34:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[st_TTxiNghiep]
		@magv varchar(50),
		@namHoc varchar(50)
AS
	select mh.TenMon,mh.SoTiet,l.TenLop,l.SiSo, mh.MaLoai, lm.TenLoai, gd.SoSV
from GiangDay gd, Lop l, MonHoc mh, GiaoVien gv, HeDaoTao hdt, LoaiMon lm
where gd.MaGV=gv.MaGV and gd.MaLop=l.MaLop and gd.NamHoc=@namHoc and gd.MaMon=mh.MaMon and hdt.MaHDT=mh.MaHeDT and hdt.MaHDT=l.MaHeDT and gv.MaGV=@magv  and lm.MaLoai=mh.MaLoai
 and mh.MaLoai like N'LM04'
group by  gd.MaGV,l.HinhThucDT,gv.TenGV, l.TenLop, l.SiSo,  mh.SoTiet, mh.MaHeDT,hdt.TenHeDT, mh.MaMon, mh.TenMon,mh.MaLoai, lm.TenLoai,gd.SoSV
	RETURN

GO
/****** Object:  StoredProcedure [dbo].[SuaHocVien]    Script Date: 3/10/2022 12:34:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROCEDURE [dbo].[SuaHocVien]
@ma varchar(30),
@NamHoc varchar(30),
@GhiChu nvarchar(100)
AS
Update  HocBSNangCao set NamHoc=@NamHoc, GhiChu=@GhiChu where Ma=@ma
RETURN
GO
/****** Object:  StoredProcedure [dbo].[ThemHocVien]    Script Date: 3/10/2022 12:34:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ThemHocVien]

@MaGV varchar(50),
@NamHoc varchar(30),
@GhiChu nvarchar(100)
AS
	insert into HocBSNangCao values(@MaGV,@NamHoc,@GhiChu)
	RETURN
GO
/****** Object:  StoredProcedure [dbo].[Thongke]    Script Date: 3/10/2022 12:34:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Thongke]
@magv varchar(50)
as
begin
select gd.MaGV,gv.TenGV, l.TenLop, l.SiSo,l.HinhThucDT,  mh.SoTiet, hdt.TenHeDT,  mh.TenMon
from GiangDay gd, Lop l, MonHoc mh, GiaoVien gv, HeDaoTao hdt
where gd.MaGV=gv.MaGV and gd.MaLop=l.MaLop and gd.MaMon=mh.MaMon and hdt.MaHDT=mh.MaHeDT and hdt.MaHDT=l.MaHeDT and gd.MaGV=@magv
group by  gd.MaGV,l.HinhThucDT,gv.TenGV, l.TenLop, l.SiSo,  mh.SoTiet, mh.MaHeDT,hdt.TenHeDT, mh.MaMon, mh.TenMon
end
return
GO
/****** Object:  StoredProcedure [dbo].[Thongtincanhan]    Script Date: 3/10/2022 12:34:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROCEDURE [dbo].[Thongtincanhan]
@tendangnhap varchar(50)
AS
/*declare	@username nvarchar(100),
 @fullname nvarchar(100),
 @birthday datetime,
@mail nvarchar(150),
 @gender nvarchar(20),
 @IdentityCard nvarchar(30),
 @Address nvarchar(300),
 @PhoneNumber nvarchar(20),
@RegistrationDate datetime,
 @Decendalization nvarchar(50),
 @Status nvarchar(20)*/
begin 

select tk.*, gv.*, cd.machucdanh,cd.tenchucdanh from taikhoan  tk, giaovien gv, giochuan cd where tk.magv=gv.magv 
and cd.machucdanh=gv.machucdanh 
 and tk.tendangnhap=@tendangnhap
end
return
GO
/****** Object:  StoredProcedure [dbo].[ThongTinHocNangCao]    Script Date: 3/10/2022 12:34:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROCEDURE [dbo].[ThongTinHocNangCao]
@maGV varchar(50),
@namHoc varchar(30)
AS
	Select MaGV from HocBSNangCao where MaGV=@maGV and NamHoc=@namHoc
	RETURN

GO
/****** Object:  StoredProcedure [dbo].[XoaHocVien]    Script Date: 3/10/2022 12:34:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROCEDURE [dbo].[XoaHocVien]
@ma varchar(30)
AS
Delete from HocBSNangCao where Ma=@ma
RETURN
GO
