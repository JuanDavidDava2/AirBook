using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AirBook.Models;
using AirBook.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace AirBook.Pages.Itinerarios
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly AirBookDbContext _context;

        public IndexModel(AirBookDbContext context)
        {
            _context = context;
        }

        public IList<Itinerario> Itinerarios { get; set; } = default!;
        public async Task OnGetAsync()
        {
            if (_context.Itinerarios != null)
            {
                Itinerarios = await _context.Itinerarios
                    .Include(r => r.Reserva)
                    .ToListAsync();
            }
        }
    }
}
