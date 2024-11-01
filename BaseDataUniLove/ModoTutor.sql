CREATE TABLE [dbo].[ModoTutor] (
    [Asignaturas]           INT          NOT NULL,
    [RetoAcademico]         VARCHAR (50) NOT NULL,
    [Aprender]              VARCHAR (50) NOT NULL,
    [TiempoEstudio]         VARCHAR (50) NOT NULL,
    [TecnicasEstudio]       VARCHAR (50) NOT NULL,
    [ObjetivoAcademico]     VARCHAR (50) NOT NULL,
    [MotivaAprender]        VARCHAR (50) NOT NULL,
    [EstudioSoloAcompañado] VARCHAR (50) NOT NULL,
    [OrganizaProyectos]     VARCHAR (50) NOT NULL,
    [LograrTrabajando]      VARCHAR (50) NOT NULL,
    [idUsuario]             INT          NOT NULL,
    FOREIGN KEY ([idUsuario]) REFERENCES [dbo].[Usuarios] ([IdUsuario])
);
