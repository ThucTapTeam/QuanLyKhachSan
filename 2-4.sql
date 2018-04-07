﻿create database QLKS

use QLKS
create table PHONG(
	MAPHONG VARCHAR(9) PRIMARY KEY,
	TENPHONG VARCHAR(10),
	MALOAI INT CHECK (MALOAI>0 AND MALOAI<3) REFERENCES LOAIPHONG(MALOAI),
	GIATHUE INT,
	SOTANG INT CHECK(SOTANG>1 AND SOTANG<6)
)
ALTER TABLE PHONG ADD SOTANG INT CHECK(SOTANG>0 AND SOTANG<3)

CREATE TABLE LOAIPHONG(
	MALOAI INT CHECK (MALOAI>0 AND MALOAI<3) PRIMARY KEY,
	TENLOAI NVARCHAR(30),
	GHICHU NVARCHAR(30),
)
CREATE TABLE NHANVIEN(
	MANHANVIEN VARCHAR(8) PRIMARY KEY,
	PASS VARCHAR(30),
	HOTEN NVARCHAR(50),
	GIOITINH NVARCHAR(6) CHECK(GIOITINH=N'Nam' or GIOITINH=N'Nữ'),
	NGAYSINH DATE,
	SODIENTHOAI VARCHAR(12),
)
CREATE TABLE KHACHHANG(
	MAKHACHHANG VARCHAR(8) PRIMARY KEY,
	TENKHACHHANG NVARCHAR(50),
	GIOITINH NVARCHAR(6) CHECK(GIOITINH=N'Nam' or GIOITINH=N'Nữ'),
	DIACHI NVARCHAR(30),
	SODIENTHOAIKH VARCHAR(12),
)

CREATE TABLE THUEPHONG(
	MATHUE VARCHAR(8) PRIMARY KEY,
	MAKHACHHANG VARCHAR(8) REFERENCES KHACHHANG(MAKHACHHANG),
	MAPHONG VARCHAR(9) REFERENCES PHONG(MAPHONG),
	NGAYVAO DATETIME,
	NGAYRA DATETIME,
	DATCOC INT,
)
CREATE TABLE DICHVU(
	MADICHVU VARCHAR(10) PRIMARY KEY,
	TENDICHVU NVARCHAR(30),
	GIATIEN INT,
)
CREATE TABLE SUDUNGDICHVU(
	MASD VARCHAR(8) PRIMARY KEY,
	MATHUE VARCHAR(8) REFERENCES THUEPHONG(MATHUE),
	MADICHVU VARCHAR(10) REFERENCES DICHVU(MADICHVU),
	NGAYSUDUNG DATETIME,
	DONGIA INT,
)
CREATE TABLE THANHTOAN(
	MATHUE VARCHAR(8) REFERENCES THUEPHONG(MATHUE),
	THANHTIEN INT,
	HINHTHUCTHANHTOAN INT CHECK (HINHTHUCTHANHTOAN>0 AND HINHTHUCTHANHTOAN<3),
	GHICHU NVARCHAR(30),
	NGAYTHANHTOAN DATETIME,	
)
select * from LOAIPHONG
INSERT INTO LOAIPHONG VALUES(1,N'Phòng Thường',N'Phòng gồm 1 giường đôi')
INSERT INTO LOAIPHONG VALUES(2,N'Phòng VIP',N'Phòng gồm 2 giường đôi')
insert into PHONG values('P201','Phòng 201' ,1,2000,2)
insert into PHONG values('P202','Phòng 202' ,1,2200,2)
insert into PHONG values('P203','Phòng 203' ,1,2200,2)

insert into PHONG values('P301','Phòng 301' ,1,2000,3)
insert into PHONG values('P302','Phòng 302' ,1,2200,3)
insert into PHONG values('P303','Phòng 303' ,1,2200,3)
insert into PHONG values('P304','Phòng 304' ,1,2000,3)
insert into PHONG values('P305','Phòng 305' ,1,2200,3)
insert into PHONG values('P306','Phòng 306' ,1,2200,3)

insert into KHACHHANG VALUES('KH12345',N'Trương Quang Hải',N'Nam',N'Thanh Hóa','0967125182')
insert into KHACHHANG VALUES('KH12346',N'Trương Quang Hải',N'Nam',N'Thanh Hóa','0967125182')
insert into KHACHHANG VALUES('KH12347',N'Trương Quang Hải',N'Nam',N'Thanh Hóa','0967125182')
insert into THUEPHONG VALUES('TP12345','KH12345','P201','20180405','20180410',500)
insert into THUEPHONG VALUES('TP12346','KH12346','P202','20180405','20180410',500)
insert into THUEPHONG VALUES('TP12347','KH12347','P303','20180405','20180410',500)
insert into THUEPHONG VALUES('TP12348','KH12345','P301','20180405','20180410',500)
select count(TENPHONG) FROM PHONG 
select tenphong from THUEPHONG RIGHT JOIN PHONG ON THUEPHONG.MAPHONG=PHONG.MAPHONG  WHERE THUEPHONG.MAPHONG is null and PHONG.SOTANG=2 and phong.MAPHONG='P203' ORDER BY TENPHONG
select tenphong from THUEPHONG INNER JOIN PHONG ON NGAYRA>cast(getdate() as date) AND THUEPHONG.MAPHONG=PHONG.MAPHONG and PHONG.SOTANG=2 and phong.MAPHONG='P202'