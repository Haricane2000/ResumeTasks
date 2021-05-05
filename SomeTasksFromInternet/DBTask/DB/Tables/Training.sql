CREATE TABLE [dbo].[Training]
(
	[Id] uniqueidentifier NOT NULL constraint [PK_dbo_Training] PRIMARY KEY,
	[Title] nvarchar(64) not null,
	[StartDate] date not null check ([StartDate] >= '2001-01-01'),
	[EndDate] date not null check ([EndDate] >= [StartDate]),
	[Description] nvarchar
)
