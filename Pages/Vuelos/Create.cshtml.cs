using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AirBook.Data;
using AirBook.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AirBook.Pages.Vuelos
{
    public class CreateModel : PageModel
    {
        private readonly AirBookDbContext _context;

        public CreateModel(AirBookDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["AerolineaId"] = new SelectList(_context.Aerolineas, "IdAerolinea", "NombreAerolinea");
            return Page();
        }

        [BindProperty]
        public Vuelo Vuelo { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Vuelos == null || Vuelo == null)
            {
                return Page();
            }

            _context.Vuelos.Add(Vuelo);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
