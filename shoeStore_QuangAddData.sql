CREATE database ShoeStore
GO
use ShoeStore
GO
Create table Product(
	Product_ID nchar(20) not null,
	Product_Name Nvarchar(50),
	Manufacturer_ID char(20),
	Price int,
	Rating int,
	Src1 nvarchar(100),
	Src2 nvarchar(100),
	Src3 nvarchar(100),
)
GO
create table Manufacturer(
	Manufacturer_ID char(20) not null,
	Manufacturer_Name nvarchar(50)
)
GO
create table Customer(
	Customer_ID nchar(20) not null,
	Customer_Name nvarchar(50),
	Company_Name nvarchar(50),
	E_mail nchar(50),
	C_Password nchar(20),
	C_Address nvarchar(200),
	Country nvarchar(50),
	City nvarchar(50),
	Phone_Number nchar(20)
)
GO

ALTER TABLE Customer
ADD Customer_UserName nchar(30)
GO

--Thuộc tính
--VD Attribute_ID = 'COLOR'
--	 Attribute_Name = 'COLOR'	
create table Attribute(
	Attribute_ID nchar(20) not null,
	Attribute_Name nvarchar(50),
)
GO
--Một thuộc tính (attribute) thì được phân ra nhiều loại VD: size có size 40,41,42 ...Mỗi size là 1 loại & được tạo mã riêng
--VD: Attribute_Type_ID = 'R'
--	  Attribute_Type_Name = 'RED'
--    Attribute_ID = 'COLOR'
create table Attribute_Type(
	Attribute_Type_ID nchar(20) not null,
	Attribute_Type_Name nvarchar(50),
	Attribute_ID nchar(20) not null
)
GO
--Một sản phẩm sẽ có nhiều thuộc tính khác nhau
--VD Product_ID = 'P1'
--	 Attribute_ID = 'COLOR'
--	 Attribute_Type_ID = 'R'
-- =>Sản phẩm mã P1 có mã thuộc tính 'COLOR' thuộc loại có mã 'R'
-- =>Ta sẽ suy ra được tên sản phẩm, thuộc tính màu sắc của sản phẩm là gì
-- Tương tự với các thuộc tính khác
create table Product_Attribute(
	Product_ID nchar(20) not null,
	Attribute_ID nchar(20) not null,
	Attribute_Type_ID nchar(20) not null
)
GO

CREATE TABLE Account_Admin (
	Ac_Name nvarchar(50) not null,
	Ac_Password nchar(20) not null
)
go

--Set primary key
ALTER TABLE Product
ADD CONSTRAINT PK_Product PRIMARY KEY (Product_ID)
ALTER TABLE Manufacturer
ADD CONSTRAINT PK_Manufacturer PRIMARY KEY (Manufacturer_ID)
ALTER TABLE Customer
ADD CONSTRAINT PK_Customer PRIMARY KEY (Customer_ID)
ALTER TABLE Attribute
ADD CONSTRAINT PK_Attribute PRIMARY KEY (Attribute_ID)
ALTER TABLE Attribute_Type
ADD CONSTRAINT PK_Attribute_Type PRIMARY KEY (Attribute_Type_ID,Attribute_ID)
ALTER TABLE Product_Attribute
ADD CONSTRAINT PK_Product_Attribute PRIMARY KEY (Product_ID,Attribute_ID,Attribute_Type_ID)
ALTER TABLE Account_Admin
ADD CONSTRAINT PK_Account_Admin PRIMARY KEY (Ac_Name)
GO


--Set foreign key
ALTER TABLE Product
ADD CONSTRAINT FK_Product
FOREIGN KEY (Manufacturer_ID) REFERENCES Manufacturer(Manufacturer_ID)

ALTER TABLE Attribute_Type
ADD CONSTRAINT FK_Attribute_Type
FOREIGN KEY (Attribute_ID) REFERENCES Attribute(Attribute_ID)

ALTER TABLE Product_Attribute
ADD CONSTRAINT FK_Product_Attribute_Product
FOREIGN KEY (Product_ID) REFERENCES Product(Product_ID)

ALTER TABLE Product_Attribute
ADD CONSTRAINT FK_Product_Attribute_Attribute
FOREIGN KEY (Attribute_ID) REFERENCES Attribute(Attribute_ID)

--ALTER TABLE Product_Attribute
--ADD CONSTRAINT FK_Product_Attribute_Attribute_Type
--FOREIGN KEY (Attribute_Type_ID) REFERENCES Attribute_Type(Attribute_Type_ID)
GO



INSERT INTO Manufacturer(Manufacturer_ID, Manufacturer_Name)
VALUES ('MAN001', N'Converse'),
	   ('MAN002', N'Nike'),
	   ('MAN003', N'Adidas'),
	   ('MAN004', N'Reebok'),
	   ('MAN005', N'Puma');
GO   

INSERT INTO Product(Product_ID, Product_Name, Manufacturer_ID, Price, Rating, Src1, Src2, Src3)
VALUES ('PRO0001', N'Nike Metcon', 'MAN002', 1000, 4, 'link1', 'link2', 'link3'),
	   ('PRO0002', N'Presto Fly', 'MAN002', 1200, 5, 'link1', 'link2', 'link3'),
	   ('PRO0003', N'Adidas BC0834', 'MAN003', 800, 5, 'link1', 'link2', 'link3'),
	   ('PRO0004', N'Adidas F36331', 'MAN003', 2000, 4, 'link1', 'link2', 'link3'),
	   ('PRO0005', N'Quickchase', 'MAN004', 1500, 4, 'link1', 'link2', 'link3');
GO	   





INSERT INTO Customer(Customer_ID, Customer_Name, Company_Name, E_mail, C_Password, C_Address, Country, City, Phone_Number)
VALUES ('CUS00001', N'Cristiano Ronaldo', 'Juventus', 'ronaldo@gmail.com', '12345', 'CLB Juventus', 'Italia', 'Torino', '01234567832'),
	   ('CUS00002', N'Leonel Messi', 'Barcelona', 'messi@gmail.com', '12346', 'CLB Barcelona', 'Spain', 'Barcelona', '01234567833'),
	   ('CUS00003', N'Luka Modric', 'Real Madrid', 'modric@gmail.com', '12347', 'CLB Real Madrid', 'Spain', 'Madrid', '01234567834'),
	   ('CUS00004', N'Nguyễn Trung Thành', 'manchester united', 'BauDa@gmail.com', '12348', N'CLB Bầu Đá', N'Việt Nam', 'Bình Định', '01234567835'),
	   ('CUS00005', N'Lữ Thái Học', 'manchester city', 'SongNuoc@gmail.com', '12349', N'CLB Sông Nước', N'Việt Nam', 'Bến Tre', '01234567836');
GO  

INSERT INTO Attribute(Attribute_ID, Attribute_Name)
VALUES ('SIZE', N'kích thước'),
	   ('COLOR', N'màu');
GO


INSERT INTO Attribute_Type(Attribute_Type_ID, Attribute_Type_Name, Attribute_ID)
VALUES ('RED', N'màu đỏ', 'COLOR'),
	   ('BLUE', N'màu lam', 'COLOR'),
	   ('GREEN', N'màu lục', 'COLOR'),
	   ('WHITE', N'màu trắng', 'COLOR'),
	   ('BLACK', N'màu đen', 'COLOR'),
	   ('S', N'size S', 'SIZE'),
	   ('M', N'size M', 'SIZE'),
	   ('L', N'size L', 'SIZE');
GO   

INSERT INTO Product_Attribute(Product_ID, Attribute_ID, Attribute_Type_ID)
VALUES ('PRO0001', 'COLOR', 'RED'),
	   ('PRO0002', 'COLOR', 'BLUE'),
	   ('PRO0003', 'COLOR', 'GREEN'),
	   ('PRO0004', 'COLOR', 'BLACK'),
	   ('PRO0001', 'SIZE', 'M'),
	   ('PRO0002', 'SIZE', 'L'),
	   ('PRO0003', 'SIZE', 'S'),
	   ('PRO0004', 'SIZE', 'L');
GO   

UPDATE Customer
SET Customer_UserName = 'Ronaldo07'
WHERE Customer_ID = 'CUS00001';
UPDATE Customer
SET Customer_UserName = 'Messi10'
WHERE Customer_ID = 'CUS00002';
UPDATE Customer
SET Customer_UserName = 'Moric999'
WHERE Customer_ID = 'CUS00003';
UPDATE Customer
SET Customer_UserName = 'CaveBD98'
WHERE Customer_ID = 'CUS00004';
UPDATE Customer
SET Customer_UserName = 'KenBoyDz98'
WHERE Customer_ID = 'CUS00005';
GO