CREATE TABLE [dbo].[sysdiagrams] (
    [diagram_id]   INT             IDENTITY (1, 1) NOT NULL,
    [name]         NVARCHAR (128)  NOT NULL,
    [principal_id] INT             NOT NULL,
    [version]      INT             NULL,
    [definition]   VARBINARY (MAX) NULL,
    CONSTRAINT [PK_dbo.sysdiagrams] PRIMARY KEY CLUSTERED ([diagram_id] ASC)
);

