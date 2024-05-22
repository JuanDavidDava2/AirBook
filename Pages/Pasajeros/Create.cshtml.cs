using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AirBook.Data;
using AirBook.Models;

namespace AirBook.Pages.Pasajeros
{
    public class CreateModel : PageModel
    {
        private readonly AirBookDbContext _context;
        public CreateModel(AirBookDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Pasajero Pasajeros { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Pasajeros == null || Pasajeros == null)
            {
                return Page();
            }

            _context.Pasajeros.Add(Pasajeros);

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
