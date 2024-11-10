//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.RazorPages;
//using UniLove.Models;

//namespace UniLove.Pages
//{
//    public class CrearCuentaModoAmigosModel : PageModel
//    {
//        private readonly ApplicationDbContext _context;

//        public CrearCuentaModoAmigosModel(ApplicationDbContext context)
//        {
//            _context = context;
//        }

//        [BindProperty]
//        public ModoAmigos ModoAmigos { get; set; }

//        public void OnGet()
//        {
//        }

//        public IActionResult OnPost()
//        {
//            if (!ModelState.IsValid)
//            {
//                return Page();
//            }

//            _context.ModosAmigos.Add(ModoAmigos);
//            _context.SaveChanges();

//            return RedirectToPage("/Navegacion");
//        }
//    }
//}
