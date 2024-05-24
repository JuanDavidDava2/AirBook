using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AirBook.Data;
using AirBook.Models;

namespace AirBook.Pages.Vuelos
{
    public class IndexModel : PageModel
    {
        private readonly AirBookDbContext _context;

        public IndexModel(AirBookDbContext context)
        {
            _context = context;
        }

        public IList<Vuelo> Vuelos { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Vuelos != null)
            {
                Vuelos = await _context.Vuelos
                    .Include(v => v.Aerolinea)
                    .ToListAsync();
            }
        }
    }
}
