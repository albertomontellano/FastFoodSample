CREATE DATABASE FastFoodDb

CREATE TABLE Persons
(
	[PersonId] [INT] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Name] [VARCHAR](8000) NOT NULL,
	[Nit] [VARCHAR](8000) NOT NULL,
	[Address] [VARCHAR](8000) NOT NULL,
	[PhoneNumber] [VARCHAR](8000) NOT NULL,
	[CreatedDate] [DATETIME] NOT NULL,
	[AddressLatitude] [VARCHAR](8000) NOT NULL,
	[AddressLongitude] [VARCHAR](8000) NOT NULL
);

CREATE TABLE Products
(
	[ProductId] [INT] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Name] [VARCHAR](8000) NOT NULL,
	[Description] [VARCHAR](8000) NOT NULL,
	[Price] [decimal](19,4) NOT NULL,
	[CreatedDate] [DATETIME] NOT NULL,
	[ImageLocation] [VARCHAR](8000) NOT NULL,
);

CREATE TABLE Orders
(
	[OrderId] [INT] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[PersonId] [INT],
	[CreatedDate] [DATETIME] NOT NULL,
	[TotalPrice] [decimal](19,4) NOT NULL
);

CREATE TABLE OrdersProducts
(
	OrderId [INT],
	ProductId [INT]
	CONSTRAINT PK_OrdersProducts PRIMARY KEY NONCLUSTERED ([OrderId], [ProductId])
);				