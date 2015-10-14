CREATE TABLE [dbo].[TripLocations] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [Name]       NVARCHAR (MAX) NULL,
    [Address]    NVARCHAR (MAX) NULL,
    [City]       NVARCHAR (MAX) NULL,
    [Directions] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.TripLocations] PRIMARY KEY CLUSTERED ([Id] ASC)
);

