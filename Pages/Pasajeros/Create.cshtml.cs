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
       
        private readonly AirBookDbContext _context; // Asegúrate de que el contexto está inyectado correctamente

        [BindProperty]
        public Pasajero Pasajero { get; set; } // Asegúrate de que el modelo está correctamente definido

        public CreateModel(AirBookDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Pasajeros.Add(Pasajero);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
