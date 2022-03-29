CREATE TABLE ContactPersons (
	Id int not null identity primary key,
	FirstName nvarchar(50) not null,
	LastName nvarchar(50) not null,
	Email nvarchar(100) not null
)

CREATE TABLE Customers (
	Id int not null identity primary key,
	Name nvarchar(50) not null,
	ContactPersonId int not null references ContactPersons(Id)
)