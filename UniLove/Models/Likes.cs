using UniLove.Models;

public class Likes
{
    public int IdLikes { get; set; } // Clave primaria
    public int IdUsuario { get; set; }
    public int LikedUserId { get; set; }
    public DateTime FechaLike { get; set; }

}


