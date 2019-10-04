CREATE TABLE [dbo].[User]
(
	[Id] INT NOT NULL PRIMARY KEY identity, 
    [AuthUserId] NVARCHAR(128) NOT NULL, 
    [FirstName] NCHAR(50) NOT NULL, 
    [LastName] NCHAR(50) NOT NULL, 
    [EmailAddress] NCHAR(256) NOT NULL, 
    [CreationDate] DATETIME2 NOT NULL DEFAULT getutcdate()
)

GO

CREATE INDEX [IX_User_AuthUserId] ON [dbo].[User] ([AuthUserId])
