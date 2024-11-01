CREATE TABLE [dbo].[ModoAmigos] (
    [MejorAmigo]      VARCHAR (50) NOT NULL,
    [TiempoLibre]     VARCHAR (50) NOT NULL,
    [PlanIdeal]       VARCHAR (50) NOT NULL,
    [Humor]           VARCHAR (50) NOT NULL,
    [FormaFavorita]   VARCHAR (50) NOT NULL,
    [ValorAmistad]    VARCHAR (50) NOT NULL,
    [GrupoAmigos]     VARCHAR (50) NOT NULL,
    [MejorRecuerdo]   VARCHAR (50) NOT NULL,
    [EquivocarAmigo]  VARCHAR (50) NOT NULL,
    [CualidadAmistad] VARCHAR (50) NOT NULL,
    [idUsuario]       INT          NOT NULL,
    FOREIGN KEY ([idUsuario]) REFERENCES [dbo].[Usuarios] ([IdUsuario])
);
