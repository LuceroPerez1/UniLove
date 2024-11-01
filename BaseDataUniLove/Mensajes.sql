CREATE TABLE [dbo].[Mensajes]
(
	[IdMensajes] INT NOT NULL PRIMARY KEY IDENTITY, 
    [idEnviado] INT NOT NULL, 
    [idRecibido] INT NOT NULL, 
    [MensajeTexto] TEXT NOT NULL, 
    [Enviado] DATETIME NOT NULL, 
    [Leido] NCHAR(10) NOT NULL,
	FOREIGN KEY ([idEnviado]) REFERENCES [dbo].[Usuarios] ([IdUsuario]),
	FOREIGN KEY ([idRecibido]) REFERENCES [dbo].[Usuarios] ([IdUsuario])
)
