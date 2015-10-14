CREATE TABLE [dbo].[Intersections] (
    [Id]    INT            IDENTITY (1, 1) NOT NULL,
    [Name]  NVARCHAR (MAX) NULL,
    [POIId] INT            NOT NULL,
    CONSTRAINT [PK_dbo.Intersections] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.Intersections_dbo.POIs_POIId] FOREIGN KEY ([POIId]) REFERENCES [dbo].[POIs] ([id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_POIId]
    ON [dbo].[Intersections]([POIId] ASC);

