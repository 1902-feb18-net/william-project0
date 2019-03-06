-- Project0 Table setup
select * from Customer
select * from Store
select * from Product
select * from SubProduct
select * from ProductGroup
select * from OrderBatch
select * from OrderItem
select * from Inventory

delete from Customer where ID > 0
delete from Product where ID > 0
delete from OrderBatch where ID = 5
--insert testing data
insert into Store (Name) values
	('Amazon'),
	('Micro Center')

insert into SubProduct (Name) values
	('CPU B'),
	('Motherboard B'),
	('GPU A'),
	('GPU B'),
	('Case A'),
	('Case B'),
	('PSU A'),
	('PSU B')

insert into Product (Name, Cost) values
	('Combo B', 350),
	('CPU A', 300),
	('CPU B', 250),
	('Motherboard A', 150),
	('Motherboard B', 100),
	('GPU A', 700),
	('GPU B', 500),
	('Case A', 100),
	('Case B', 50),
	('PSU A', 100),
	('PSU B', 75)

insert into ProductGroup (ProductID, SubProductID) values
	(5,3),
	(5,4),
	(6,1),
	(7,3),
	(8,2),
	(9,4),
	(10,5),
	(11,6),
	(12,7),
	(13,8),
	(14,9),
	(15,10)

insert into OrderBatch (CustomerID,StoreID) values
	(4,6)

insert into OrderItem (BatchID, ProductID, Name, Quantity, Cost) values
	(1, 4,'Combo A', 1, 450)

-- Adds store location
create table Store (
	ID int not null primary key identity,
	Name nvarchar(50),
	Address nvarchar(100),

)

-- Adds Customer
create table Customer (
	ID int not null primary key identity,
	StoreID int not null foreign key references Store (ID),
	FirstName nvarchar(100),
	LastName nvarchar(100),
	Address nvarchar(100),
	PhoneNumber nvarchar(20),
)

-- Adds individual products split to lowest form
create table SubProduct (
	ID int not null primary key identity,
	Name nvarchar(100) not null
)

-- Adds Products
create table Product (
	ID int not null primary key identity,
	Name nvarchar(100) not null,
	Cost money not null
)

-- Links Products with their possibly many SubProducts
create table ProductGroup (
	ID int not null primary key identity,
	ProductID int null foreign key references Product (ID),
	SubProductID int null foreign key references SubProduct (ID)
)

-- Links Store with Collection of SubProducts
create table Inventory (
	ID int not null primary key identity,
	StoreID int not null foreign key references Store (ID),
	SubProductID int not null foreign key references SubProduct (ID),
	Quantity int not null
)

-- Adds Order and Links Customer to Location
create table OrderBatch (
	ID int not null primary key identity,
	CustomerID int not null foreign key references Customer (ID),
	StoreID int not null foreign key references Store (ID),
	TimePlaced datetime2 not null default(getdate())
)

-- Links Group of orders to their products
drop table OrderItem
create table OrderItem (
	ID int not null primary key,
	BatchID int not null foreign key references OrderBatch (ID),
	ProductID int null foreign key references Product (ID),
	Quantity int not null,
	Name nvarchar(100) not null,
	Cost money not null
)