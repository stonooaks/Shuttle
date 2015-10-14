CREATE TABLE [dbo].[Vehicles] (
    [Id]   INT            IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.Vehicles] PRIMARY KEY CLUSTERED ([Id] ASC)
);

