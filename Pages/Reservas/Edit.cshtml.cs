using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AirBook.Data;
using AirBook.Models;

namespace AirBook.Pages.R
{
    public class EditModel : PageModel
    {
        private readonly AirBookDbContext _context;

        public EditModel(AirBookDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Pasajero Pasajero { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Pasajeros == null)
            {
                return NotFound();
            }

            var category = await _context.Pasajeros.FirstOrDefaultAsync(m => m.IdPasajero == id);
            if (category == null)
            {
                return NotFound();
            }
            Pasajero = category;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Pasajero).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(Pasajero.IdPasajero))
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
            return (_context.Pasajeros?.Any(e => e.IdPasajero == id)).GetValueOrDefault();
        }
    }
}

