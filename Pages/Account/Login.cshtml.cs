using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AirBook.Models;
using Microsoft.Identity.Client.Platforms.Features.DesktopOs;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;

namespace AirBook.Pages.Account
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public User User { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            //Se crea los claim, datos almacenados en la cookie
            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,"admin"),
                    new Claim(ClaimTypes.Email,User.Email),
                };

            //se asocia los claims creados a un nombre de una cookie
            var identity = new ClaimsIdentity(claims, "MyCookieAuth");
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);
            //Se registra exitosamente la autenticacion y se crea la cookie en el navegador
            await HttpContext.SignInAsync("MyCookieAuth", claimsPrincipal);
            return RedirectToPage("/index");
        }
    }
}
