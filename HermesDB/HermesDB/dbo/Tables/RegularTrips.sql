CREATE TABLE [dbo].[RegularTrips] (
    [MemberId]  INT NOT NULL,
    [RegularId] INT NOT NULL,
    CONSTRAINT [PK_dbo.RegularTrips] PRIMARY KEY CLUSTERED ([MemberId] ASC, [RegularId] ASC),
    CONSTRAINT [FK_dbo.RegularTrips_dbo.Members_MemberId] FOREIGN KEY ([MemberId]) REFERENCES [dbo].[Members] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.RegularTrips_dbo.Regulars_RegularId] FOREIGN KEY ([RegularId]) REFERENCES [dbo].[Regulars] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_MemberId]
    ON [dbo].[RegularTrips]([MemberId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_RegularId]
    ON [dbo].[RegularTrips]([RegularId] ASC);

