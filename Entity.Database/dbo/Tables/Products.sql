CREATE TABLE [dbo].[Products] (
    [Id]          BIGINT         IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (MAX) NOT NULL,
    [Description] NVARCHAR (MAX) NOT NULL,
    [Price]       DECIMAL (6, 2) NOT NULL,
    [SellerId]    BIGINT         NOT NULL,
    [CreatedAt]   DATETIME2 (7)  DEFAULT (getutcdate()) NOT NULL,
    [UpdatedAt]   DATETIME2 (7)  DEFAULT (getutcdate()) NOT NULL,
    CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Products_Shops_SellerId] FOREIGN KEY ([SellerId]) REFERENCES [dbo].[Shops] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Products_SellerId]
    ON [dbo].[Products]([SellerId] ASC);

