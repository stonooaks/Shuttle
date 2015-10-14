CREATE TABLE [dbo].[DailyHours] (
    [id]        INT        IDENTITY (1, 1) NOT NULL,
    [Day]       DATETIME   NOT NULL,
    [Miles]     FLOAT (53) NOT NULL,
    [VehicleId] INT        NULL,
    CONSTRAINT [PK_dbo.DailyHours] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_dbo.DailyHours_dbo.Vehicles_VehicleId] FOREIGN KEY ([VehicleId]) REFERENCES [dbo].[Vehicles] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_VehicleId]
    ON [dbo].[DailyHours]([VehicleId] ASC);

