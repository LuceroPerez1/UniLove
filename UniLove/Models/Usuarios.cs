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
    }
}



