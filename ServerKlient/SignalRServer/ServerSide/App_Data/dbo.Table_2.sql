CREATE TABLE [dbo].[Groups]
(
	[GroupId] INT NOT NULL, 
    [AdminId] INT NOT NULL, 
    CONSTRAINT [FK_Groups_ToUsers] FOREIGN KEY ([GroupId]) REFERENCES [Users]([UserId]), 
    CONSTRAINT [FK_Groups_ToAdmins] FOREIGN KEY ([AdminId]) REFERENCES [Admins]([AdminId]) 
)
