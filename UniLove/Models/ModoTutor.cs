namespace UniLove.Models
{
    public class ModoTutor
    {
        public int IdModoTutor { get; set; } // Asegúrate de incluir un ID para la entidad
        public int Asignaturas { get; set; }
        public string RetoAcademico { get; set; }
        public string Aprender { get; set; }
        public string TiempoEstudio { get; set; }
        public string TecnicasEstudio { get; set; }
        public string ObjetivoAcademico { get; set; }
        public string MotivaAprender { get; set; }
        public string EstudioSoloAcompañado { get; set; }
        public string OrganizaProyectos { get; set; }
        public string LograrTrabajando { get; set; }
        public int IdUsuario { get; set; } // Foreign key
    }
}

