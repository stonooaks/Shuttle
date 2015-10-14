CREATE TABLE [dbo].[AdditionalTrip] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [RegularId]    INT            NOT NULL,
    [AdditionalId] INT            NOT NULL,
    [Number]       INT            NOT NULL,
    [Notes]        NVARCHAR (225) NULL,
    CONSTRAINT [PK_dbo.AdditionalTrip] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.AdditionalTrip_dbo.Additional_AdditionalId] FOREIGN KEY ([AdditionalId]) REFERENCES [dbo].[Additional] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.AdditionalTrip_dbo.Regulars_RegularId] FOREIGN KEY ([RegularId]) REFERENCES [dbo].[Regulars] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_RegularId]
    ON [dbo].[AdditionalTrip]([RegularId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AdditionalId]
    ON [dbo].[AdditionalTrip]([AdditionalId] ASC);

