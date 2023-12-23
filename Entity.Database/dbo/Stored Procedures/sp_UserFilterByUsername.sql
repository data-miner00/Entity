CREATE PROCEDURE [dbo].[sp_UserFilterByUsername]
	@Username NVARCHAR(50)
AS
BEGIN
	SELECT * FROM dbo.Users
	WHERE Username LIKE '%' + @Username + '%';
END
RETURN 0
