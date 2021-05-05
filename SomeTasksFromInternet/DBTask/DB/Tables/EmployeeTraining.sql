CREATE TABLE [dbo].[EmployeeTraining]
(
    [EmployeeId] UNIQUEIDENTIFIER CONSTRAINT [FK_dbo_EmployeeTraining_dbo_Employee] FOREIGN KEY REFERENCES [dbo].[Employee]([Id]) ON DELETE CASCADE,
    [TrainingId] UNIQUEIDENTIFIER CONSTRAINT [FK_dbo_EmployeeTraining_dbo_Training] FOREIGN KEY REFERENCES [dbo].[Training]([Id]) ON DELETE CASCADE,
    CONSTRAINT [PK_dbo_EmployeeTraining] PRIMARY KEY ([EmployeeId], [TrainingId]),
);
