CREATE TABLE [dbo].[BillingAddresses] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Address2]    NVARCHAR (MAX) NULL,
    [City]        NVARCHAR (MAX) NULL,
    [State]       NVARCHAR (MAX) NULL,
    [ZipCode]     NVARCHAR (MAX) NULL,
    [Country]     NVARCHAR (MAX) NULL,
    [Address1]    NVARCHAR (MAX) NULL,
    [HouseholdId] INT            NULL,
    CONSTRAINT [PK_dbo.BillingAddresses] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.BillingAddresses_dbo.Households_HouseholdId] FOREIGN KEY ([HouseholdId]) REFERENCES [dbo].[Households] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_HouseholdId]
    ON [dbo].[BillingAddresses]([HouseholdId] ASC);

