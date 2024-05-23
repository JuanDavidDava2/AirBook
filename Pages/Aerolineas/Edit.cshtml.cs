using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AirBook.Data;
using AirBook.Models;

namespace AirBook.Pages.Aerolineas
{
    public class EditModel : PageModel
    {
        private readonly AirBookDbContext _context;

        public EditModel(AirBookDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Aerolinea Aerolinea { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Aerolineas == null)
            {
                return NotFound();
            }

            var aerolinea = await _context.Aerolineas.FirstOrDefaultAsync(m => m.IdAerolinea == id);

            if (aerolinea == null)
            {
                return NotFound();
            }
            Aerolinea = aerolinea;
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Aerolinea).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(Aerolinea.IdAerolinea))
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
            return (_context.Aerolineas?.Any(e => e.IdAerolinea == id)).GetValueOrDefault();
        }
    }
}
