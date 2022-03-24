CREATE TABLE CurrencyEntity (
	CurrencyCode char(3) not null primary key,
	Currency nvarchar(250) not null,
	Country nvarchar(250) null
)

CREATE TABLE VendorEntity (
	Id int not null identity primary key,
	Name nvarchar(100) not null unique
)

CREATE TABLE CategoryEntity (
	Id int not null identity primary key,
	Name nvarchar(100) not null unique
)
GO

CREATE TABLE SubCategoryEntity (
	Id int not null identity primary key,
	CategoryId int not null references CategoryEntity(Id),
	Name nvarchar(100) not null unique
)
GO

CREATE TABLE ProductEntity (
	Id int not null identity primary key,
	SubCategoryId int not null references SubCategoryEntity(Id),
	VendorId int not null references VendorEntity(Id),
	Barcode varchar(13) null,
	Name nvarchar(250) not null,
	Description nvarchar(max) null,
	Modified datetime2 not null
)
GO

CREATE TABLE PriceListEntity (
	ProductId int not null references ProductEntity(Id),
	CurrencyCode char(3) not null references CurrencyEntity(CurrencyCode),
	Price decimal not null,
	Modified datetime2 not null

	primary key (ProductId)
)

CREATE TABLE SkuEntity (
	ProductId int not null references ProductEntity(Id),
	Modified datetime2 not null,
	Quantity int not null

	primary key (ProductId)
)