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
        public string Contrase�a { get; set; }

        public string ErrorMessage { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            // Busca al usuario en la base de datos
            var usuario = _context.Usuarios
                .FirstOrDefault(u => u.NombreUsuario == NombreUsuario && u.Contrase�a == Contrase�a);

            if (usuario != null)
            {
                HttpContext.Session.SetString("modoJuego", usuario.ModoJuego);
                // Autenticaci�n exitosa
                return RedirectToPage("/Navegacion"); // Redirige a la p�gina de navegaci�n
            }
            else
            {
                // Autenticaci�n fallida
                ErrorMessage = "Usuario o contrase�a incorrectos";
                return Page(); // Vuelve a cargar la misma p�gina con el mensaje de error
            }
        }
    }
}
