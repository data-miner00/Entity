CREATE TABLE [dbo].[Addresses] (
    [Id]            BIGINT         IDENTITY (1, 1) NOT NULL,
    [UserProfileId] BIGINT         NULL,
    [ShopId]        BIGINT         NULL,
    [Street1]       NVARCHAR (MAX) NOT NULL,
    [Street2]       NVARCHAR (MAX) NULL,
    [City]          NVARCHAR (MAX) NOT NULL,
    [State]         NVARCHAR (MAX) NOT NULL,
    [PostalCode]    NVARCHAR (MAX) NOT NULL,
    [Country]       NVARCHAR (MAX) NOT NULL,
    [CreatedAt]     DATETIME2 (7)  DEFAULT (getutcdate()) NOT NULL,
    [UpdatedAt]     DATETIME2 (7)  DEFAULT (getutcdate()) NOT NULL,
    CONSTRAINT [PK_Addresses] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Addresses_Shops_ShopId] FOREIGN KEY ([ShopId]) REFERENCES [dbo].[Shops] ([Id]),
    CONSTRAINT [FK_Addresses_UserProfiles_UserProfileId] FOREIGN KEY ([UserProfileId]) REFERENCES [dbo].[UserProfiles] ([Id])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Addresses_ShopId]
    ON [dbo].[Addresses]([ShopId] ASC) WHERE ([ShopId] IS NOT NULL);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Addresses_UserProfileId]
    ON [dbo].[Addresses]([UserProfileId] ASC) WHERE ([UserProfileId] IS NOT NULL);

