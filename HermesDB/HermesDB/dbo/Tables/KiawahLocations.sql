CREATE TABLE [dbo].[KiawahLocations] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [Name]       NVARCHAR (MAX) NULL,
    [Address]    NVARCHAR (MAX) NULL,
    [City]       NVARCHAR (MAX) NULL,
    [Directions] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.KiawahLocations] PRIMARY KEY CLUSTERED ([Id] ASC)
);

