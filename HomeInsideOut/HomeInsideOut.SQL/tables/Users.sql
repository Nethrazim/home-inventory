CREATE TABLE [dbo].[Users]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Username] varchar(64),
	[Email] varchar(320),
	[HashedPassword] nvarchar(255),
	[Salt] nvarchar(64)
)
