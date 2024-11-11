using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using UniLove.Models;

namespace UniLove.Pages
{
    public class NavegacionModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        // Propiedad para almacenar el usuario que se obtiene con el mismo modo de juego
        public Usuarios Usuarios { get; set; }

        // El valor del ModoJuego para el usuario actual
        public string ModoJuego { get; set; }

        public NavegacionModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            // Recuperar el ModoJuego del usuario actual desde la sesi�n o alg�n otro mecanismo
            ModoJuego = HttpContext.Session.GetString("modoJuego");

            // Si el ModoJuego es null o vac�o, asignar un valor predeterminado
            if (string.IsNullOrEmpty(ModoJuego))
            {
                ModoJuego = "Modo predeterminado"; // Valor por defecto si no se encuentra en la sesi�n
            }

            // Obtener un usuario que tenga el mismo ModoJuego
            Usuarios = _context.Usuarios
                .Where(u => u.ModoJuego == ModoJuego)
                .OrderBy(r => Guid.NewGuid()) // Orden aleatorio para obtener un usuario aleatorio con el mismo modo
                .FirstOrDefault(); // Tomar el primer usuario que coincida
        }
    }
}

