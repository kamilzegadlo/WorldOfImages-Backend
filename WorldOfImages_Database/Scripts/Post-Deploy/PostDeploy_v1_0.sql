IF EXISTS (SELECT 1 FROM sys.messages WHERE message_id=50001)
BEGIN
	EXEC sp_dropmessage 50001
END
EXEC sp_addmessage 50001, 16, N'A place with the provided coordinates alredy exists.'

IF EXISTS (SELECT 1 FROM sys.messages WHERE message_id=50002)
BEGIN
	EXEC sp_dropmessage 50002
END
EXEC sp_addmessage 50002, 16, N'An image with the given id alredy exists.'