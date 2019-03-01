-- Project0 Table setup
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
create table OrderItem (
	ID int not null primary key identity,
	BatchID int not null foreign key references OrderBatch (ID),
	ProductID int null foreign key references Product (ID),
	Quantity int not null,
	Name nvarchar(100) not null,
	Cost money not null
)