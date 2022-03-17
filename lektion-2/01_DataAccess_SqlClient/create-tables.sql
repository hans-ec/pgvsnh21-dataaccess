CREATE TABLE Categories (
	Id int not null identity primary key,
	Name nvarchar(200) not null unique
)
GO

CREATE TABLE Products (
	Id int not null identity primary key,
	Name nvarchar(200) not null,
	Price decimal not null,
	CategoryId int not null references Categories(Id)
)

