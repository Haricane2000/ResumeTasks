CREATE TABLE [dbo].[Employee]
(
	[Id] uniqueidentifier NOT NULL constraint [PK_dbo_Employee] PRIMARY KEY,
	[Email] nvarchar(128) unique not null ,
	[FirstName] nvarchar(128) not null,
	[SecondName] nvarchar(128) not null
)
