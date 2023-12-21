CREATE TABLE [dbo].[Orders] (
    [Id]             BIGINT        IDENTITY (1, 1) NOT NULL,
    [OrderFulfilled] DATETIME2 (7) NULL,
    [CustomerId]     BIGINT        NULL,
    [Status]         INT           NOT NULL,
    [SellerId]       BIGINT        NULL,
    [CreatedAt]      DATETIME2 (7) DEFAULT (getutcdate()) NOT NULL,
    [UpdatedAt]      DATETIME2 (7) DEFAULT (getutcdate()) NOT NULL,
    CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Orders_Shops_SellerId] FOREIGN KEY ([SellerId]) REFERENCES [dbo].[Shops] ([Id]),
    CONSTRAINT [FK_Orders_Users_CustomerId] FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[Users] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Orders_CustomerId]
    ON [dbo].[Orders]([CustomerId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Orders_SellerId]
    ON [dbo].[Orders]([SellerId] ASC);

