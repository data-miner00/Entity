CREATE TABLE [dbo].[Shops] (
    [Id]          BIGINT         IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (MAX) NOT NULL,
    [Description] NVARCHAR (MAX) NOT NULL,
    [OwnerId]     BIGINT         NOT NULL,
    [CreatedAt]   DATETIME2 (7)  DEFAULT (getutcdate()) NOT NULL,
    [UpdatedAt]   DATETIME2 (7)  DEFAULT (getutcdate()) NOT NULL,
    CONSTRAINT [PK_Shops] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Shops_Users_OwnerId] FOREIGN KEY ([OwnerId]) REFERENCES [dbo].[Users] ([Id]) ON DELETE CASCADE
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Shops_OwnerId]
    ON [dbo].[Shops]([OwnerId] ASC);

