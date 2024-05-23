using AirBook.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AirBook.Models;

namespace AirBook.Pages.Pasajeros
{
    public class DeleteModel : PageModel
    {
		private readonly AirBookDbContext _context;
		public DeleteModel(AirBookDbContext context)
		{
			_context = context;
		}

		[BindProperty]
		public Pasajero Pasajero { get; set; }

		public async Task<IActionResult> OnGetAsync(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var pasajero = await _context.Pasajeros.FirstOrDefaultAsync(m => m.IdPasajero == id);


			if (pasajero == null)
			{
				return NotFound();
			}

			return Page();
		}
		public async Task<IActionResult> OnPostAsync(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var pasajero = await _context.Pasajeros.FindAsync(id);

			if (pasajero != null)
			{
				Pasajero = Pasajero;
				_context.Pasajeros.Remove(pasajero);
				await _context.SaveChangesAsync();

			}

			return RedirectToPage("./Index");
		}
	}
}
