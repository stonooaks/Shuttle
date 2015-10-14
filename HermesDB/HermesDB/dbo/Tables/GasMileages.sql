CREATE TABLE [dbo].[GasMileages] (
    [Id]        INT      IDENTITY (1, 1) NOT NULL,
    [Date]      DATETIME NOT NULL,
    [Mileage]   REAL     NOT NULL,
    [Gallons]   REAL     NOT NULL,
    [VehicleId] INT      NULL,
    CONSTRAINT [PK_dbo.GasMileages] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.GasMileages_dbo.Vehicles_VehicleId] FOREIGN KEY ([VehicleId]) REFERENCES [dbo].[Vehicles] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_VehicleId]
    ON [dbo].[GasMileages]([VehicleId] ASC);

