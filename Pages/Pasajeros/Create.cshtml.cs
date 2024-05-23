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
       
        private readonly AirBookDbContext _context; // Aseg�rate de que el contexto est� inyectado correctamente

        [BindProperty]
        public Pasajero Pasajero { get; set; } // Aseg�rate de que el modelo est� correctamente definido

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
