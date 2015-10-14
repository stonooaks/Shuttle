CREATE TABLE [dbo].[Ownership] (
    [HouseholdId]       INT NOT NULL,
    [KiawahLocationsId] INT NOT NULL,
    CONSTRAINT [PK_dbo.Ownership] PRIMARY KEY CLUSTERED ([HouseholdId] ASC, [KiawahLocationsId] ASC),
    CONSTRAINT [FK_dbo.Ownership_dbo.Households_HouseholdId] FOREIGN KEY ([HouseholdId]) REFERENCES [dbo].[Households] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.Ownership_dbo.KiawahAddresses_KiawahLocationsId] FOREIGN KEY ([KiawahLocationsId]) REFERENCES [dbo].[KiawahAddresses] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_HouseholdId]
    ON [dbo].[Ownership]([HouseholdId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_KiawahLocationsId]
    ON [dbo].[Ownership]([KiawahLocationsId] ASC);

