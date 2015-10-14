CREATE TABLE [dbo].[FamilyRoles] (
    [Id]             INT           IDENTITY (1, 1) NOT NULL,
    [Description]    NVARCHAR (50) NULL,
    [AuthorizedUser] BIT           NULL,
    CONSTRAINT [PK_dbo.FamilyRoles] PRIMARY KEY CLUSTERED ([Id] ASC)
);

