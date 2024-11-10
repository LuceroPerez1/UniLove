using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UniLove.Models;

namespace UniLove.Pages
{
    public class DatosPersonalesModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DatosPersonalesModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Usuarios Usuarios { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Usuarios.Add(Usuarios);
            _context.SaveChanges();

            return RedirectToPage("/Navegacion");
        }
    }
}




