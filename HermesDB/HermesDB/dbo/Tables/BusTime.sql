CREATE TABLE [dbo].[BusTime] (
    [Id]           INT           NOT NULL,
    [StopTime]     TIME (7)      NULL,
    [StopLocation] NVARCHAR (50) NULL,
    CONSTRAINT [PK_dbo.BusTime] PRIMARY KEY CLUSTERED ([Id] ASC)
);

