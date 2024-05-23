using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AirBook.Data;
using AirBook.Models;
using Microsoft.EntityFrameworkCore;

namespace AirBook.Pages.Aerolineas
{
    public class DeleteModel : PageModel
    {
        private readonly AirBookDbContext _context;

        public DeleteModel(AirBookDbContext context)
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
            else
            {
                Aerolinea = aerolinea;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Aerolineas == null)
            {
                return NotFound();
            }

            var aerolinea = await _context.Aerolineas.FindAsync(id);

            if (aerolinea != null)
            {
                Aerolinea = aerolinea;
                _context.Aerolineas.Remove(aerolinea);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("./Index");
        }
    }
}
