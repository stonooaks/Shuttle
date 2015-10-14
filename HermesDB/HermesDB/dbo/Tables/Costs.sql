CREATE TABLE [dbo].[Costs] (
    [Id]          INT        IDENTITY (1, 1) NOT NULL,
    [twoperprice] FLOAT (53) NULL,
    [addperprice] FLOAT (53) NULL,
    [TripTypeId]  INT        NULL,
    CONSTRAINT [PK_dbo.Costs] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.Costs_dbo.TripTypes_TripTypeId] FOREIGN KEY ([TripTypeId]) REFERENCES [dbo].[TripTypes] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_TripTypeId]
    ON [dbo].[Costs]([TripTypeId] ASC);

