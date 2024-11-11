using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UniLove.Models;

namespace UniLove.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public string NombreUsuario { get; set; }

        [BindProperty]
        public string Contraseña { get; set; }

        public string ErrorMessage { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            // Busca al usuario en la base de datos
            var usuario = _context.Usuarios
                .FirstOrDefault(u => u.NombreUsuario == NombreUsuario && u.Contraseña == Contraseña);

            if (usuario != null)
            {
                HttpContext.Session.SetString("modoJuego", usuario.ModoJuego);
                // Autenticación exitosa
                return RedirectToPage("/Navegacion"); // Redirige a la página de navegación
            }
            else
            {
                // Autenticación fallida
                ErrorMessage = "Usuario o contraseña incorrectos";
                return Page(); // Vuelve a cargar la misma página con el mensaje de error
            }
        }
    }
}
