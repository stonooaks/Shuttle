CREATE TABLE [dbo].[Additional] (
    [Id]               INT             IDENTITY (1, 1) NOT NULL,
    [AdditionalTypeId] INT             NOT NULL,
    [Name]             NVARCHAR (50)   NOT NULL,
    [Cost]             DECIMAL (18, 2) NOT NULL,
    CONSTRAINT [PK_dbo.Additional] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.Additional_dbo.AdditionalType_AdditionalTypeId] FOREIGN KEY ([AdditionalTypeId]) REFERENCES [dbo].[AdditionalType] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_AdditionalTypeId]
    ON [dbo].[Additional]([AdditionalTypeId] ASC);

