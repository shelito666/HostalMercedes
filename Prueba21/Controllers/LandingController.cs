using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;


namespace Prueba21.Controllers
{
    [AllowAnonymous]
    public class LandingController : Controller   // ← IMPORTANTE: hereda de Controller
    {

        // Si usas Identity, inyecta UserManager (opcional para salto automático por rol)
        private readonly UserManager<IdentityUser>? _userManager;

        public LandingController(UserManager<IdentityUser>? userManager = null)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            // Si no usas Identity todavía, puedes borrar todo este bloque "autologin"
            if (User?.Identity?.IsAuthenticated == true && _userManager != null)
            {
                var u = await _userManager.GetUserAsync(User);
                if (u != null)
                {
                    if (await _userManager.IsInRoleAsync(u, "Administrador"))
                        return RedirectToAction("Index", "Home");            // panel admin

                    if (await _userManager.IsInRoleAsync(u, "Cliente"))
                        return RedirectToAction("Index", "ClienteHome");     // panel cliente
                }
            }

            return View(); // Renderiza la vista de selección
        }
    }
}

