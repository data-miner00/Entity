CREATE TABLE [dbo].[Products] (
    [Id]          INT             NOT NULL,
    [CreatedAt]   DATETIME        DEFAULT (getdate()) NOT NULL,
    [Name]        NVARCHAR (50)   NOT NULL,
    [Description] NVARCHAR (2000) NULL,
    [Price]       MONEY           NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

GO
    CREATE NONCLUSTERED INDEX IX_Product_CreatedAt
    ON [dbo].[Products] ([CreatedAt] ASC);

