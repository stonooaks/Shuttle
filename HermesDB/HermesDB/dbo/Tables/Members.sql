CREATE TABLE [dbo].[Members] (
    [Id]            INT            NOT NULL,
    [Name]          NVARCHAR (MAX) NULL,
    [FamilyRolesId] INT            NULL,
    [Email]         NVARCHAR (MAX) NULL,
    [HouseholdId]   INT            NOT NULL,
    CONSTRAINT [PK_dbo.Members] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.Members_dbo.FamilyRoles_FamilyRolesId] FOREIGN KEY ([FamilyRolesId]) REFERENCES [dbo].[FamilyRoles] ([Id]),
    CONSTRAINT [FK_dbo.Members_dbo.Households_HouseholdId] FOREIGN KEY ([HouseholdId]) REFERENCES [dbo].[Households] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_FamilyRolesId]
    ON [dbo].[Members]([FamilyRolesId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_HouseholdId]
    ON [dbo].[Members]([HouseholdId] ASC);

