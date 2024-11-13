using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UniLove.Models;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace UniLove.Pages
{
    public class PerfilModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        // Propiedad para almacenar los datos del usuario
        [BindProperty]
        public Usuarios Usuarios { get; set; }

        public PerfilModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            int? idUsuario = HttpContext.Session.GetInt32("IdUsuario");
            if (idUsuario == null)
            {
                return RedirectToPage("/Index");
            }

            Usuarios = await _context.Usuarios.FindAsync(idUsuario);
            if (Usuarios == null)
            {
                return RedirectToPage("/Index");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            // Obtener el IdUsuario de la sesión
            int? idUsuario = HttpContext.Session.GetInt32("IdUsuario");
            if (idUsuario == null)
            {
                return RedirectToPage("/Index");
            }

            // Buscar el usuario en la base de datos
            var usuarioEnDb = await _context.Usuarios.FindAsync(idUsuario);
            if (usuarioEnDb == null)
            {
                return RedirectToPage("/Index");
            }

            // Actualizar los campos editables
            usuarioEnDb.NombreUsuario = Usuarios.NombreUsuario;
            usuarioEnDb.CorreoElectronico = Usuarios.CorreoElectronico;
            usuarioEnDb.Contraseña = Usuarios.Contraseña;

            // Guardar cambios en la base de datos
            await _context.SaveChangesAsync();

            // Redirigir a la misma página para mostrar los datos actualizados
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostDeleteAsync()
        {
            // Obtener el IdUsuario de la sesión
            int? idUsuario = HttpContext.Session.GetInt32("IdUsuario");
            if (idUsuario == null)
            {
                return RedirectToPage("/Index");
            }

            // Buscar el usuario en la base de datos
            var usuarioEnDb = await _context.Usuarios.FindAsync(idUsuario);
            if (usuarioEnDb == null)
            {
                return RedirectToPage("/Index");
            }

            // Eliminar el usuario de la base de datos
            _context.Usuarios.Remove(usuarioEnDb);

            // Guardar cambios en la base de datos
            await _context.SaveChangesAsync();

            // Eliminar el IdUsuario de la sesión
            HttpContext.Session.Remove("IdUsuario");

            // Redirigir a la página de inicio después de eliminar la cuenta
            return RedirectToPage("/Index");
        }

    }
}


