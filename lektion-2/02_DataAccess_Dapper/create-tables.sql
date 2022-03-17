CREATE TABLE Categories (
	Id int not null identity primary key,
	Name nvarchar(200) not null unique
)