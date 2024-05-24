using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Razor;
using AirBook.Data;
using AirBook.Models;
using Microsoft.EntityFrameworkCore;

namespace AirBook.Pages.Itinerarios
{
    public class EditModel : PageModel
    {
        private readonly AirBookDbContext _context;

        public EditModel(AirBookDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Itinerario Itinerario { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Itinerarios == null)
            {
                return NotFound();
            }

            var itinerario = await _context.Itinerarios.FirstOrDefaultAsync(m => m.IdItinerario == id);
            if (itinerario == null)
            {
                return NotFound();
            }
            Itinerario = itinerario;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Itinerario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(Itinerario.IdItinerario))
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
            return (_context.Itinerarios?.Any(e => e.IdItinerario == id)).GetValueOrDefault();
        }

    }
}
