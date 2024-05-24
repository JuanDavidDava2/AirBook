using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Razor;
using AirBook.Data;
using AirBook.Models;

namespace AirBook.Pages.Aerolineas
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

        public Aerolinea Aerolinea { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Aerolineas == null || Aerolinea == null)
            {
                return Page();
            }
            _context.Aerolineas.Add(Aerolinea);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
