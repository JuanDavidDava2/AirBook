using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AirBook.Models;
using AirBook.Data;
using Microsoft.EntityFrameworkCore;

namespace AirBook.Pages.Aerolineas
{
    public class IndexModel : PageModel
    {
        private readonly AirBookDbContext _context;

        public IndexModel(AirBookDbContext context)
        {
            _context = context;
        }

        public IList<Aerolinea> Aerolineas { get; set; } = default!;
        public async Task OnGetAsync()
        {
            if (_context.Aerolineas != null)
            {
                Aerolineas = await _context.Aerolineas.ToListAsync();
            }
        }
    }
}
