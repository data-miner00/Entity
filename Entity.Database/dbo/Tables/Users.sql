CREATE TABLE [dbo].[Users] (
    [Id]        BIGINT         IDENTITY (1, 1) NOT NULL,
    [Username]  NVARCHAR (MAX) NOT NULL,
    [CreatedAt] DATETIME2 (7)  DEFAULT (getutcdate()) NOT NULL,
    [UpdatedAt] DATETIME2 (7)  DEFAULT (getutcdate()) NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([Id] ASC)
);

