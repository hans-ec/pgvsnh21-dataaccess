CREATE TABLE Addresses (
	Id int not null identity primary key,
	StreetName nvarchar(100) not null,
	PostalCode nvarchar(50) not null,
	City nvarchar(50) not null
)

CREATE TABLE Customers (
	Id int not null identity primary key,
	FirstName nvarchar(50) not null,
	LastName nvarchar(50) not null,
	Email nvarchar(100) not null,
	AddressId int not null references Addresses(Id)
)

