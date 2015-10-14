CREATE TABLE [dbo].[Regulars] (
    [Id]              INT            IDENTITY (1, 1) NOT NULL,
    [HHID]            INT            NOT NULL,
    [MemberId]        INT            NULL,
    [TripTypeId]      INT            NOT NULL,
    [KiawahLocation]  NVARCHAR (50)  NOT NULL,
    [TripLocation]    NVARCHAR (50)  NOT NULL,
    [NonKiawahPickup] BIT            NOT NULL,
    [DriverId]        INT            NULL,
    [Date]            DATETIME       NOT NULL,
    [PickupTime]      TIME (7)       NOT NULL,
    [OfficerName]     NVARCHAR (50)  NOT NULL,
    [VehicleId]       INT            NULL,
    [Email]           NVARCHAR (50)  NOT NULL,
    [Notes]           NVARCHAR (MAX) NULL,
    [IsCancelled]     BIT            NOT NULL,
    [otherAddress]    NVARCHAR (50)  NULL,
    [Phone]           NVARCHAR (50)  NOT NULL,
    [Count]           INT            NULL,
    [Cost]            FLOAT (53)     NULL,
    CONSTRAINT [PK_dbo.Regulars] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.Regulars_dbo.Drivers_DriverId] FOREIGN KEY ([DriverId]) REFERENCES [dbo].[Drivers] ([Id]),
    CONSTRAINT [FK_dbo.Regulars_dbo.Households_HHID] FOREIGN KEY ([HHID]) REFERENCES [dbo].[Households] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.Regulars_dbo.Members_MemberId] FOREIGN KEY ([MemberId]) REFERENCES [dbo].[Members] ([Id]),
    CONSTRAINT [FK_dbo.Regulars_dbo.TripTypes_TripTypeId] FOREIGN KEY ([TripTypeId]) REFERENCES [dbo].[TripTypes] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.Regulars_dbo.Vehicles_VehicleId] FOREIGN KEY ([VehicleId]) REFERENCES [dbo].[Vehicles] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_HHID]
    ON [dbo].[Regulars]([HHID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_MemberId]
    ON [dbo].[Regulars]([MemberId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_TripTypeId]
    ON [dbo].[Regulars]([TripTypeId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_DriverId]
    ON [dbo].[Regulars]([DriverId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_VehicleId]
    ON [dbo].[Regulars]([VehicleId] ASC);

