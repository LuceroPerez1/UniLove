CREATE TABLE [dbo].[Likes]
(
	[IdLikes] INT NOT NULL PRIMARY KEY IDENTITY, 
    [idUsuario] INT NOT NULL, 
    [likedUserId] INT NOT NULL, 
    [FechaLike] DATETIME NOT NULL,
	FOREIGN KEY ([idUsuario]) REFERENCES [dbo].[Usuarios] ([IdUsuario]),
	FOREIGN KEY ([likedUserId]) REFERENCES [dbo].[Usuarios] ([IdUsuario])
)