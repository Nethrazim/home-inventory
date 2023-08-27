CREATE TABLE [dbo].[Users]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Username] varchar(64) not null,
	[Email] varchar(320) not null,
	[HashedPassword] nvarchar(255) not null,
	[Salt] nvarchar(64) not null
)
