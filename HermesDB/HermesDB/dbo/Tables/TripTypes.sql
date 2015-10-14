CREATE TABLE [dbo].[TripTypes] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (MAX) NULL,
    [Description] NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_dbo.TripTypes] PRIMARY KEY CLUSTERED ([Id] ASC)
);

