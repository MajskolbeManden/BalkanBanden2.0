CREATE TABLE [dbo].[Messages]
(
	[MessagesId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [GroupId] INT NOT NULL, 
    [Date&Time] DATETIME NOT NULL, 
    [Message] VARCHAR(MAX) NOT NULL, 
    [SenderName] VARCHAR(MAX) NOT NULL, 
    CONSTRAINT [FK_Messages_ToUsers] FOREIGN KEY ([GroupId]) REFERENCES [Users]([UserId])
)
