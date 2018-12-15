CREATE PROCEDURE [dbo].[GetPlace]
	@x int,
	@y int
AS
	SELECT [x],[y],[name] 
		FROM [Place] 
		WHERE [x]=@x AND [y]=@y
RETURN 0
