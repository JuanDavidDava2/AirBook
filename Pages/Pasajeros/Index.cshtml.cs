using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AirBook.Data;
using AirBook.Models;

namespace AirBook.Pages.Pasajeros
{
    public class IndexModel : PageModel
    {
        private readonly AirBookDbContext _context;

        public IndexModel(AirBookDbContext context)
        {
            _context = context;
        }

        public IList<Pasajero> Pasajeros { get; set; }
        public async Task OnGetAsync()
        {

            Pasajeros = await _context.Pasajeros.ToListAsync();

        }
    }
}
