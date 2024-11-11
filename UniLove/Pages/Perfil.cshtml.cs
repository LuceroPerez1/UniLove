using Microsoft.AspNetCore.Mvc.RazorPages;
using UniLove.Models;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace UniLove.Pages
{
    public class PerfilModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        // Propiedad para almacenar los datos completos del usuario
        public Usuarios Usuario { get; set; }

        public PerfilModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task OnGetAsync()
        {
            // Obtener el IdUsuario desde la sesión
            int? idUsuario = HttpContext.Session.GetInt32("IdUsuario");

            // Si no hay IdUsuario en la sesión, redirige a la página de inicio de sesión
            if (idUsuario == null)
            {
                RedirectToPage("/Index");
                return;
            }

            // Buscar al usuario en la base de datos utilizando su IdUsuario
            Usuario = await _context.Usuarios.FindAsync(idUsuario);

            // Si el usuario no existe en la base de datos (caso improbable)
            if (Usuario == null)
            {
                RedirectToPage("/Index");
            }
        }
    }
}

