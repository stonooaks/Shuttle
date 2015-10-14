CREATE TABLE [dbo].[Buses] (
    [Id]         INT      IDENTITY (1, 1) NOT NULL,
    [StopsId]    INT      NOT NULL,
    [TripTypeId] INT      NOT NULL,
    [Kiawah_Id]  INT      NULL,
    [DriverId]   INT      NOT NULL,
    [BusTimeId]  INT      NULL,
    [Date]       DATETIME NULL,
    [GuestId]    INT      NULL,
    CONSTRAINT [PK_dbo.Buses] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.Buses_dbo.BusTime_BusTimeId] FOREIGN KEY ([BusTimeId]) REFERENCES [dbo].[BusTime] ([Id]),
    CONSTRAINT [FK_dbo.Buses_dbo.Drivers_DriverId] FOREIGN KEY ([DriverId]) REFERENCES [dbo].[Drivers] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.Buses_dbo.Guests_GuestId] FOREIGN KEY ([GuestId]) REFERENCES [dbo].[Guests] ([Id]),
    CONSTRAINT [FK_dbo.Buses_dbo.Intersections_StopsId] FOREIGN KEY ([StopsId]) REFERENCES [dbo].[Intersections] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.Buses_dbo.Kiawahs_Kiawah_Id] FOREIGN KEY ([Kiawah_Id]) REFERENCES [dbo].[Kiawahs] ([Id]),
    CONSTRAINT [FK_dbo.Buses_dbo.RouteStops_StopsId] FOREIGN KEY ([StopsId]) REFERENCES [dbo].[RouteStops] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.Buses_dbo.TripTypes_TripTypeId] FOREIGN KEY ([TripTypeId]) REFERENCES [dbo].[TripTypes] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_StopsId]
    ON [dbo].[Buses]([StopsId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_TripTypeId]
    ON [dbo].[Buses]([TripTypeId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Kiawah_Id]
    ON [dbo].[Buses]([Kiawah_Id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_DriverId]
    ON [dbo].[Buses]([DriverId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_BusTimeId]
    ON [dbo].[Buses]([BusTimeId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_GuestId]
    ON [dbo].[Buses]([GuestId] ASC);

