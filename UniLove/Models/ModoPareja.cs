namespace UniLove.Models
{
    public class ModoPareja
    {
        public int IdModoPareja { get; set; } // Asegúrate de incluir un ID para la entidad
        public string RelacionSentimental { get; set; }
        public string SignoZodiacal { get; set; }
        public string Salida { get; set; }
        public string ValorRelacion { get; set; }
        public string ExtrovertidoIntrovertido { get; set; }
        public string CitaIdeal { get; set; }
        public string Lealtad { get; set; }
        public string Musica { get; set; }
        public int IdUsuario { get; set; } // Foreign key
    }
}
