CREATE PROCEDURE [dbo].[AddImage]
	@Id UNIQUEIDENTIFIER,
	@x INT,
	@y INT,
	@path NVARCHAR(128)
AS
	IF EXISTS (SELECT 1 FROM [Image] WHERE [Id]=@Id)
		   RAISERROR (50002, 16,  1);  

	INSERT INTO [Image] ([x],[y],[path])
		SELECT @x, @y, @path
RETURN 0
