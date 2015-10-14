CREATE TABLE [dbo].[Phones] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [Number]   NVARCHAR (MAX) NULL,
    [MemberId] INT            NULL,
    CONSTRAINT [PK_dbo.Phones] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.Phones_dbo.Members_MemberId] FOREIGN KEY ([MemberId]) REFERENCES [dbo].[Members] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_MemberId]
    ON [dbo].[Phones]([MemberId] ASC);

