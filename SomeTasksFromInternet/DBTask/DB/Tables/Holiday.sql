CREATE TABLE [dbo].[Holiday]
(
	[Id] uniqueidentifier NOT NULL constraint [PK_dbo_Holiday] PRIMARY KEY,
	[StartHolidayDate] date not null check([StartHolidayDate] >= '2001-01-01'),
	[EndHolidayDate] date not null check([EndHolidayDate]>= [StartHolidayDate]),
	[EmployeeId] uniqueidentifier null constraint[FR_dbo_Holiday_dbo_Employee] REFERENCES [dbo].[Employee] ([Id]) ON DELETE SET NULL
)
