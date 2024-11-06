namespace UniLove.Models
{
    public class Mensaje
    {
        public int IdMensajes { get; set; }
        public int IdEnviado { get; set; } // Foreign key
        public int IdRecibido { get; set; } // Foreign key
        public string MensajeTexto { get; set; }
        public DateTime Enviado { get; set; }
        public int Leido { get; set; }
    }
}

