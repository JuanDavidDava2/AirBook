using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AirBook.Data;
using AirBook.Models;
using Microsoft.EntityFrameworkCore;

namespace AirBook.Pages.Itinerarios
{
    public class DeleteModel : PageModel
    {
        private readonly AirBookDbContext _context;

        public DeleteModel(AirBookDbContext context)
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
            else
            {
                Itinerario = itinerario;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Itinerarios == null)
            {
                return NotFound();
            }

            var itinerario = await _context.Itinerarios.FindAsync(id);

            if (itinerario != null)
            {
                Itinerario = itinerario;
                _context.Itinerarios.Remove(itinerario);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("./Index");
        }
    }
}
