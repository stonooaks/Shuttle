CREATE TABLE [dbo].[ReturnTrip] (
    [Id]             INT           IDENTITY (1, 1) NOT NULL,
    [RegularId]      INT           NOT NULL,
    [PickupTime]     TIME (7)      NULL,
    [TripLocation]   NVARCHAR (50) NULL,
    [KiawahLocation] NVARCHAR (50) NULL,
    CONSTRAINT [PK_dbo.ReturnTrip] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.ReturnTrip_dbo.Regulars_RegularId] FOREIGN KEY ([RegularId]) REFERENCES [dbo].[Regulars] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_RegularId]
    ON [dbo].[ReturnTrip]([RegularId] ASC);

