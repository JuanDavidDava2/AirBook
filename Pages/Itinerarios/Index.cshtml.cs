using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AirBook.Models;
using AirBook.Data;
using Microsoft.EntityFrameworkCore;

namespace AirBook.Pages.Itinerarios

{
    public class IndexModel : PageModel
    {
        private readonly AirBookDbContext _context;

        public IndexModel(AirBookDbContext context)
        {
            _context = context;
        }

        public IList<Aerolinea> Itinerarios { get; set; } = default!;
        public async Task OnGetAsync()
        {
            if (_context.Itinerarios != null)
            {
                Itinerarios = (IList<Aerolinea>)await _context.Itinerarios.ToListAsync();
            }
        }
    }
}
