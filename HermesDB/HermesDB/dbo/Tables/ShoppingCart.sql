CREATE TABLE [dbo].[ShoppingCart] (
    [Id]               INT        IDENTITY (1, 1) NOT NULL,
    [RegularId]        INT        NOT NULL,
    [TotalCost]        FLOAT (53) NULL,
    [ShoppingCartDate] DATETIME   NULL,
    [HouseholdID]      INT        NOT NULL,
    CONSTRAINT [PK_dbo.ShoppingCart] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.ShoppingCart_dbo.Regulars_RegularId] FOREIGN KEY ([RegularId]) REFERENCES [dbo].[Regulars] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_RegularId]
    ON [dbo].[ShoppingCart]([RegularId] ASC);

