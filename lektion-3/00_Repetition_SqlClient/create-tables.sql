CREATE TABLE Customers (
	Id int not null identity primary key,
	FirstName nvarchar(50) not null,
	LastName nvarchar(50) not null,
	Email nvarchar(100) not null
)

CREATE TABLE Addresses (
	Id int not null identity primary key,
	AddressLine nvarchar(100) not null,
	PostalCode nvarchar(100) not null,
	City nvarchar(100) not null
)
GO

CREATE TABLE CustomerAddresses  (
	CustomerId int not null references Customers(Id),
	AddressId int not null references Addresses(Id)

	primary key (CustomerId, AddressId)
)





-- 1	Hans	Mattin-Lassei	hans@domain.com		Nordkapsvägen 1		136 57		Vega
