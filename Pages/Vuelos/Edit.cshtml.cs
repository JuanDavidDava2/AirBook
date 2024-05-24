using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AirBook.Data;
using AirBook.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AirBook.Pages.Vuelos
{
    public class EditModel : PageModel
    {
        private readonly AirBookDbContext _context;

        public EditModel(AirBookDbContext context)
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

            var vuelo = await _context.Vuelos.FirstOrDefaultAsync(m => m.IdVuelo == id);

            if (vuelo == null)
            {
                return NotFound();
            }
            Vuelo = vuelo;
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Vuelo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(Vuelo.IdVuelo))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CategoryExists(int id)
        {
            return (_context.Vuelos?.Any(e => e.IdVuelo == id)).GetValueOrDefault();
        }
    }
}
