CREATE PROCEDURE [dbo].[AddPlace]
	@x INT,
	@y INT,
	@name NVARCHAR(128)
AS
	IF EXISTS (SELECT 1 FROM [Place] WHERE [x]=@x AND [y]=@y)
		   RAISERROR (50001, 16,  1);  

	INSERT INTO [Place]([x],[y],[name])
		SELECT @x,@y,@name
RETURN 0
