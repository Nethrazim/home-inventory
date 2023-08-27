CREATE TABLE [dbo].[Inventory]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
	[Name] varchar(255) not null,
	[Quantity] int default(0) not null,
	[LowLimit] int default(0) not null
	CONSTRAINT UK_Name UNIQUE(Name)
)
