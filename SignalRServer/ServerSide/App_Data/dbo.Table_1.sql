CREATE TABLE [dbo].[Admins]
(
	[AdminId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [AdminName] VARCHAR(MAX) NOT NULL, 
    [AdminPassword] VARCHAR(MAX) NOT NULL
)
