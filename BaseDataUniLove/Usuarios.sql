CREATE TABLE [dbo].[Usuarios] (
    [IdUsuario]         INT          IDENTITY (1, 1) NOT NULL,
    [CorreoElectronico] VARCHAR (80) NOT NULL,
    [NombreUsuario]     VARCHAR (50) NOT NULL,
    [FechaNacimiento]   DATE         NOT NULL,
    [OrientacionSexual] VARCHAR (50) NOT NULL,
    [DeseaBuscar]       VARCHAR (50) NOT NULL,
    [Genero]            VARCHAR (50) NOT NULL,
    [Facultad]          VARCHAR (70) NOT NULL,
    PRIMARY KEY CLUSTERED ([IdUsuario] ASC)
);


