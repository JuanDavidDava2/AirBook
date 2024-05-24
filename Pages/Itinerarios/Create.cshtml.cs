using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Razor;
using AirBook.Data;
using AirBook.Models;

namespace AirBook.Pages.Itinerarios
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

        public Itinerario Itinerario { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Itinerarios == null || Itinerario == null)
            {
                return Page();
            }
            _context.Itinerarios.Add(Itinerario);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}