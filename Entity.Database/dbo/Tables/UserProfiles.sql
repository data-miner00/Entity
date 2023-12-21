CREATE TABLE [dbo].[UserProfiles] (
    [Id]        BIGINT         IDENTITY (1, 1) NOT NULL,
    [FirstName] NVARCHAR (MAX) NOT NULL,
    [LastName]  NVARCHAR (MAX) NOT NULL,
    [Email]     NVARCHAR (MAX) NOT NULL,
    [Phone]     NVARCHAR (MAX) NOT NULL,
    [UserId]    BIGINT         NOT NULL,
    [CreatedAt] DATETIME2 (7)  DEFAULT (getutcdate()) NOT NULL,
    [UpdatedAt] DATETIME2 (7)  DEFAULT (getutcdate()) NOT NULL,
    CONSTRAINT [PK_UserProfiles] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_UserProfiles_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id]) ON DELETE CASCADE
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_UserProfiles_UserId]
    ON [dbo].[UserProfiles]([UserId] ASC);

