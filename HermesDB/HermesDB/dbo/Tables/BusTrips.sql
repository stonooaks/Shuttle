CREATE TABLE [dbo].[BusTrips] (
    [BusId]    INT NOT NULL,
    [MemberId] INT NOT NULL,
    CONSTRAINT [PK_dbo.BusTrips] PRIMARY KEY CLUSTERED ([BusId] ASC, [MemberId] ASC),
    CONSTRAINT [FK_dbo.BusTrips_dbo.Buses_BusId] FOREIGN KEY ([BusId]) REFERENCES [dbo].[Buses] ([Id]),
    CONSTRAINT [FK_dbo.BusTrips_dbo.Members_MemberId] FOREIGN KEY ([MemberId]) REFERENCES [dbo].[Members] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_BusId]
    ON [dbo].[BusTrips]([BusId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_MemberId]
    ON [dbo].[BusTrips]([MemberId] ASC);

