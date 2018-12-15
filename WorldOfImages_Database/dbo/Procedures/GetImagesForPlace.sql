CREATE PROCEDURE [dbo].[GetImagesForPlace]
	@x INT,
	@y INT
AS
	SELECT TOP 20 [path] 
		FROM [Image] 
		--TABLESAMPLE (1000 ROWS) this may be requeired from performane point of view if the table grow very much
		WHERE [x]=@x AND [y]=@y
		ORDER BY NEWID() --random order
RETURN 0
