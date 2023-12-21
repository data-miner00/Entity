CREATE TABLE [dbo].[OrderDetails] (
    [Id]             BIGINT         IDENTITY (1, 1) NOT NULL,
    [Quantity]       INT            NOT NULL,
    [ProductId]      BIGINT         NOT NULL,
    [OrderId]        BIGINT         NOT NULL,
    [CreatedAt]      DATETIME2 (7)  DEFAULT (getutcdate()) NOT NULL,
    [UpdatedAt]      DATETIME2 (7)  DEFAULT (getutcdate()) NOT NULL,
    [OrderUnitPrice] DECIMAL (6, 2) DEFAULT ((0.0)) NOT NULL,
    CONSTRAINT [PK_OrderDetails] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_OrderDetails_Orders_OrderId] FOREIGN KEY ([OrderId]) REFERENCES [dbo].[Orders] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_OrderDetails_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Products] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_OrderDetails_OrderId]
    ON [dbo].[OrderDetails]([OrderId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_OrderDetails_ProductId]
    ON [dbo].[OrderDetails]([ProductId] ASC);

