CREATE TABLE [dbo].[ModoPareja] (
    [RelacionSentimental]      VARCHAR (50) NOT NULL,
    [SignoZodiacal]            VARCHAR (50) NOT NULL,
    [Salida]                   VARCHAR (50) NOT NULL,
    [ValorRelacion]            VARCHAR (50) NOT NULL,
    [ExtrovertidoIntrovertido] VARCHAR (50) NOT NULL,
    [CitaIdeal]                VARCHAR (50) NOT NULL,
    [Lealtad]                  VARCHAR (50) NOT NULL,
    [Musica]                   VARCHAR (50) NOT NULL,
    [idUsuario]                INT          NOT NULL,
    FOREIGN KEY ([idUsuario]) REFERENCES [dbo].[Usuarios] ([IdUsuario])
);