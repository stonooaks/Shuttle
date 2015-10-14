CREATE TABLE [dbo].[AuthorizedUsers] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [HouseholdId] INT           NOT NULL,
    [Name]        NVARCHAR (50) NULL,
    [DateCreated] DATETIME      NULL,
    [DateExpired] DATETIME      NULL,
    CONSTRAINT [PK_dbo.AuthorizedUsers] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.AuthorizedUsers_dbo.Households_HouseholdId] FOREIGN KEY ([HouseholdId]) REFERENCES [dbo].[Households] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_HouseholdId]
    ON [dbo].[AuthorizedUsers]([HouseholdId] ASC);

