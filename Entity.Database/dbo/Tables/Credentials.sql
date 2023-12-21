CREATE TABLE [dbo].[Credentials] (
    [Id]             BIGINT         IDENTITY (1, 1) NOT NULL,
    [UserId]         BIGINT         NOT NULL,
    [HashedPassword] NVARCHAR (MAX) NOT NULL,
    [Salt]           NVARCHAR (MAX) NOT NULL,
    [HashAlgorithm]  NVARCHAR (MAX) NOT NULL,
    [CreatedAt]      DATETIME2 (7)  DEFAULT (getutcdate()) NOT NULL,
    [UpdatedAt]      DATETIME2 (7)  DEFAULT (getutcdate()) NOT NULL,
    CONSTRAINT [PK_Credentials] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Credentials_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id]) ON DELETE CASCADE
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Credentials_UserId]
    ON [dbo].[Credentials]([UserId] ASC);

