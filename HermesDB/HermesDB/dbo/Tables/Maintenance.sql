CREATE TABLE [dbo].[Maintenance] (
    [Id]          INT           NOT NULL,
    [Date]        DATETIME      NULL,
    [Type]        NVARCHAR (50) NULL,
    [Description] NVARCHAR (50) NULL,
    [Cost]        FLOAT (53)    NULL,
    [VehicleId]   INT           NULL,
    CONSTRAINT [PK_dbo.Maintenance] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.Maintenance_dbo.Vehicles_VehicleId] FOREIGN KEY ([VehicleId]) REFERENCES [dbo].[Vehicles] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_VehicleId]
    ON [dbo].[Maintenance]([VehicleId] ASC);

