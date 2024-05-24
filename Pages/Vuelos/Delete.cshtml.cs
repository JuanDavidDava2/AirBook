using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AirBook.Data;
using AirBook.Models;
using Microsoft.EntityFrameworkCore;

namespace AirBook.Pages.Vuelos
{
    public class DeleteModel : PageModel
    {
        private readonly AirBookDbContext _context;

        public DeleteModel(AirBookDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Vuelo Vuelo { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Vuelos == null)
            {
                return NotFound();
            }

            var aerolinea = await _context.Vuelos.FirstOrDefaultAsync(m => m.IdVuelo == id);

            if (aerolinea == null)
            {
                return NotFound();
            }
            else
            {
                Vuelo = Vuelo;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Vuelos == null)
            {
                return NotFound();
            }

            var vuelo = await _context.Vuelos.FindAsync(id);

            if (vuelo != null)
            {
                Vuelo = vuelo;
                _context.Vuelos.Remove(vuelo);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("./Index");
        }
    }
}
