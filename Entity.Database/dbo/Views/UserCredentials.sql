CREATE VIEW [dbo].[UserCredentials]
	AS SELECT
		[u].[Id] UID,
		[u].[Username],
		[u].[CreatedAt] UCreatedAt,
		[u].[UpdatedAt] UUpdatedAt,
		[c].[Id] CID,
		[c].[UserId],
		[c].[HashedPassword],
		[c].[Salt],
		[c].[HashAlgorithm],
		[c].[CreatedAt] CCreatedAt,
		[c].[UpdatedAt] CUpdatedAt
	FROM dbo.Users u
	LEFT JOIN dbo.Credentials c
	ON u.Id = c.UserId;
