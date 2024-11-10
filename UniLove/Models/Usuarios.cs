using System.ComponentModel.DataAnnotations;

namespace UniLove.Models
{
    public class Usuarios
    {
        [Key]
        public int IdUsuario { get; set; }
        public string CorreoElectronico { get; set; }
        public string NombreUsuario { get; set; }
        public string Contraseña { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string OrientacionSexual { get; set; }
        public string DeseaBuscar { get; set; }
        public string Genero { get; set; }
        public string Facultad { get; set; }
        public string ModoJuego { get; set; }   
        public string ValorRelacion { get; set; }
        public string TiempoLibre { get; set; }
        public string CirculoSocial { get; set; }
        public string Lealtad { get; set; }
        public string Logros { get; set; }
        public string ValorConversacion { get; set;}
        public string InteresMejorar { get; set; }
        public string ResolucionConflictos { get; set; }
    }
}



