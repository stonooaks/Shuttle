CREATE TABLE [dbo].[POIs] (
    [id]      INT            IDENTITY (1, 1) NOT NULL,
    [Name]    NVARCHAR (MAX) NOT NULL,
    [Address] NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_dbo.POIs] PRIMARY KEY CLUSTERED ([id] ASC)
);

