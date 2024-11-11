using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using UniLove.Models;

namespace UniLove.Pages
{
    public class NavegacionModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        // Propiedad para almacenar el nombre del usuario con el mismo modo de juego
        public string UsuarioModoJuego { get; set; }

        // El valor del ModoJuego para el usuario actual
        public string ModoJuego { get; set; }

        public NavegacionModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            // Recuperar el ModoJuego del usuario actual desde la sesión o algún otro mecanismo
            ModoJuego = HttpContext.Session.GetString("modoJuego");

            // Si el ModoJuego es null o vacío, asignar un valor predeterminado
            if (string.IsNullOrEmpty(ModoJuego))
            {
                ModoJuego = "Modo predeterminado"; // Valor por defecto si no se encuentra en la sesión
            }

            // Obtener un usuario que tenga el mismo ModoJuego
            var usuario = _context.Usuarios
                .Where(u => u.ModoJuego == ModoJuego)
                .OrderBy(r => Guid.NewGuid()) // Orden aleatorio para obtener un usuario aleatorio con el mismo modo
                .FirstOrDefault(); // Tomar el primer usuario que coincida

            if (usuario != null)
            {
                UsuarioModoJuego = usuario.NombreUsuario; // Asignar el nombre del usuario encontrado
            }
            else
            {
                UsuarioModoJuego = "No hay usuarios disponibles"; // Si no se encuentra ningún usuario con el mismo modo de juego
            }
        }

    }
}


