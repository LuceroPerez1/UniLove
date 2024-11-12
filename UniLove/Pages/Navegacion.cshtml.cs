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

        // Propiedad para saber si ya no hay más usuarios disponibles
        public bool NoHayMasUsuarios { get; set; }

        // Constructor que recibe el contexto de la base de datos
        public NavegacionModel(ApplicationDbContext context)
        {
            _context = context;
        }

        // Método para manejar la solicitud GET y cargar el primer usuario
        public void OnGet()
        {
            // Recuperar el IdUsuario del usuario logueado desde la sesión
            int? idUsuario = HttpContext.Session.GetInt32("IdUsuario");

            // Verificar si el usuario está logueado
            if (idUsuario == null)
            {
                // Si no hay usuario logueado, redirigir a la página principal
                RedirectToPage("/Index");
                return; // Asegura que no continúe la ejecución
            }

            // Obtener la información del usuario logueado
            UsuarioLogueado = _context.Usuarios.Find(idUsuario);

            // Si el usuario no se encuentra en la base de datos, redirigir
            if (UsuarioLogueado == null)
            {
                RedirectToPage("/Index");
                return;
            }

            // Recuperar el ModoJuego del usuario actual desde la sesión o algún otro mecanismo
            ModoJuego = HttpContext.Session.GetString("modoJuego");

            // Si el ModoJuego es null o vacío, asignar un valor predeterminado
            if (string.IsNullOrEmpty(ModoJuego))
            {
                ModoJuego = "Modo predeterminado"; // Valor por defecto si no se encuentra en la sesión
            }

            // Obtener la lista de usuarios que coinciden con el ModoJuego actual
            var usuariosModoJuego = _context.Usuarios
                .Where(u => u.ModoJuego == ModoJuego)
                .OrderBy(u => u.NombreUsuario) // Aquí puedes cambiar el orden si es necesario
                .ToList();

            // Recuperar el índice del usuario actual desde la sesión
            int currentIndex = HttpContext.Session.GetInt32("currentIndex") ?? 0;

            // Verificar si ya no hay más usuarios disponibles
            if (currentIndex >= usuariosModoJuego.Count)
            {
                UsuarioModoJuego = null; // No hay más usuarios disponibles
                NoHayMasUsuarios = true; // Marcamos que ya no hay más usuarios
                HttpContext.Session.SetInt32("currentIndex", 0); // Reseteamos el índice
            }
            else
            {
                // Obtener el siguiente usuario en la lista
                UsuarioModoJuego = usuariosModoJuego[currentIndex];
                NoHayMasUsuarios = false; // Hay más usuarios disponibles

                // Guardar el índice actualizado en la sesión
                HttpContext.Session.SetInt32("currentIndex", currentIndex + 1);
            }
        }

        // Método para manejar la acción de "Siguiente"
        public IActionResult OnPostSiguienteUsuario()
        {
            // Redirigir a la página de GET para cargar el siguiente usuario
            return RedirectToPage();
        }
    }
}


