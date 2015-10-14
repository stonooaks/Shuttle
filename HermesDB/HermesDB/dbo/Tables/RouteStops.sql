CREATE TABLE [dbo].[RouteStops] (
    [Id]    INT IDENTITY (1, 1) NOT NULL,
    [POIId] INT NOT NULL,
    CONSTRAINT [PK_dbo.RouteStops] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.RouteStops_dbo.POIs_POIId] FOREIGN KEY ([POIId]) REFERENCES [dbo].[POIs] ([id])
);


GO
CREATE NONCLUSTERED INDEX [IX_POIId]
    ON [dbo].[RouteStops]([POIId] ASC);

