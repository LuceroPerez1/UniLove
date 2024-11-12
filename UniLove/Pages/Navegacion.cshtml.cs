using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Contracts;
using System.Linq;
using UniLove.Models;

namespace UniLove.Pages
{
    public class NavegacionModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        // Propiedad para almacenar el usuario logueado
        public Usuarios UsuarioLogueado { get; set; }

        // Propiedad para almacenar el usuario en el modo de juego
        public Usuarios UsuarioModoJuego { get; set; }

        // El valor del ModoJuego para el usuario actual
        public string ModoJuego { get; set; }

        // Propiedad para saber si ya no hay m�s usuarios disponibles
        public bool NoHayMasUsuarios { get; set; }

        // Constructor que recibe el contexto de la base de datos
        public NavegacionModel(ApplicationDbContext context)
        {
            _context = context;
        }

        // M�todo para manejar la solicitud GET y cargar el primer usuario
        public void OnGet()
        {
            // Recuperar el IdUsuario del usuario logueado desde la sesi�n
            int? idUsuario = HttpContext.Session.GetInt32("IdUsuario");

            // Verificar si el usuario est� logueado
            if (idUsuario == null)
            {
                // Si no hay usuario logueado, redirigir a la p�gina principal
                RedirectToPage("/Index");
                return; // Asegura que no contin�e la ejecuci�n
            }

            // Obtener la informaci�n del usuario logueado
            UsuarioLogueado = _context.Usuarios.Find(idUsuario);

            // Si el usuario no se encuentra en la base de datos, redirigir
            if (UsuarioLogueado == null)
            {
                RedirectToPage("/Index");
                return;
            }

            // Recuperar el ModoJuego del usuario actual desde la sesi�n o alg�n otro mecanismo
            ModoJuego = HttpContext.Session.GetString("modoJuego");

            // Si el ModoJuego es null o vac�o, asignar un valor predeterminado
            if (string.IsNullOrEmpty(ModoJuego))
            {
                ModoJuego = "Modo predeterminado"; // Valor por defecto si no se encuentra en la sesi�n
            }

            // Obtener la lista de usuarios que coinciden con el ModoJuego actual
            var usuariosModoJuego = _context.Usuarios
                .Where(u => u.ModoJuego == ModoJuego)
                .OrderBy(u => u.NombreUsuario) // Aqu� puedes cambiar el orden si es necesario
                .ToList();

            // Recuperar el �ndice del usuario actual desde la sesi�n
            int currentIndex = HttpContext.Session.GetInt32("currentIndex") ?? 0;

            // Verificar si ya no hay m�s usuarios disponibles
            if (currentIndex >= usuariosModoJuego.Count)
            {
                UsuarioModoJuego = null; // No hay m�s usuarios disponibles
                NoHayMasUsuarios = true; // Marcamos que ya no hay m�s usuarios
                HttpContext.Session.SetInt32("currentIndex", 0); // Reseteamos el �ndice
            }
            else
            {
                // Obtener el siguiente usuario en la lista
                UsuarioModoJuego = usuariosModoJuego[currentIndex];
                NoHayMasUsuarios = false; // Hay m�s usuarios disponibles

                // Guardar el �ndice actualizado en la sesi�n
                HttpContext.Session.SetInt32("currentIndex", currentIndex + 1);
            }
        }

        // M�todo para manejar la acci�n de "Siguiente"
        public IActionResult OnPostSiguienteUsuario()
        {
            // Redirigir a la p�gina de GET para cargar el siguiente usuario
            return RedirectToPage();
        }
    }
}


