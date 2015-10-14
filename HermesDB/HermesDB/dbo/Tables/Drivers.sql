CREATE TABLE [dbo].[Drivers] (
    [Id]      INT            IDENTITY (1, 1) NOT NULL,
    [Name]    NVARCHAR (MAX) NULL,
    [License] NVARCHAR (MAX) NULL,
    [ShiftId] INT            NULL,
    CONSTRAINT [PK_dbo.Drivers] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.Drivers_dbo.DriverShift_ShiftId] FOREIGN KEY ([ShiftId]) REFERENCES [dbo].[DriverShift] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_ShiftId]
    ON [dbo].[Drivers]([ShiftId] ASC);

