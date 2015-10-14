CREATE TABLE [dbo].[Guests] (
    [Id]        INT           IDENTITY (1, 1) NOT NULL,
    [Name]      NVARCHAR (50) NULL,
    [RegularId] INT           NOT NULL,
    CONSTRAINT [PK_dbo.Guests] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.Guests_dbo.Regulars_RegularId] FOREIGN KEY ([RegularId]) REFERENCES [dbo].[Regulars] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_RegularId]
    ON [dbo].[Guests]([RegularId] ASC);

