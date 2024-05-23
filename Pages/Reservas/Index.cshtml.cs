using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AirBook.Models;
using AirBook.Data;
using Microsoft.EntityFrameworkCore;

namespace AirBook.Pages.Reservas
{
    public class IndexModel : PageModel
    {
        private readonly AirBookDbContext _context;

        public IndexModel(AirBookDbContext context)
        {
            _context = context;
        }

        public IList<Reserva> Reservas { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Reservas != null)
            {
                Reservas = await _context.Reservas
                    .Include(r => r.Pasajero)
                    .Include(r => r.Vuelo)
                    .ToListAsync();
            }
        }
    }
}
