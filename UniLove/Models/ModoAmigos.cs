namespace UniLove.Models
{
    public class ModoAmigos
    {
        public int IdModoAmigos { get; set; } // Asegúrate de incluir un ID para la entidad
        public string MejorAmigo { get; set; }
        public string TiempoLibre { get; set; }
        public string PlanIdeal { get; set; }
        public string Humor { get; set; }
        public string FormaFavorita { get; set; }
        public string ValorAmistad { get; set; }
        public string GrupoAmigos { get; set; }
        public string MejorRecuerdo { get; set; }
        public string EquivocarAmigo { get; set; }
        public string CualidadAmistad { get; set; }
        public int IdUsuario { get; set; } // Foreign key
    }
}

