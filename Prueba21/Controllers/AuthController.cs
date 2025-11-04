using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Prueba21.Models;
using Prueba21.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace Prueba21.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        // GET: /Auth/Login?role=Cliente|Administrador
        [AllowAnonymous]
        public IActionResult Login(string? role = null, string? returnUrl = null)
        {
            ViewBag.Role = role;          // para mostrar/propagar el rol seleccionado en la Landing
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        // POST: /Auth/Login
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string email, string contrasenia, string? role, string? returnUrl)
        {
            var usuario = await _authService.ValidarUsuario(email, contrasenia);

            if (usuario == null)
            {
                ModelState.AddModelError("Error", "Usuario o contraseña incorrectos.");
                ViewBag.Role = role; // conservar selección
                return View();
            }

            // Construir claims (incluye el rol real del usuario)
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, usuario.Email.ToString()),
                new Claim(ClaimTypes.Name, usuario.Nombre),
                new Claim(ClaimTypes.Email, usuario.Email),
                new Claim(ClaimTypes.Role, usuario.Rol)  // "Administrador" o "Cliente"
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties { IsPersistent = true };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties
            );

            // 1) Si vino el rol desde la Landing, redirige según esa intención
            if (!string.IsNullOrEmpty(role))
            {
                if (role == "Administrador")
                    return RedirectToAction("Index", "Home");

                if (role == "Cliente")
                    return RedirectToAction("Index", "ClienteHome");
            }

            // 2) Si no vino role, decide por el rol REAL del usuario
            if (usuario.Rol == "Administrador" || User.IsInRole("Administrador"))
                return RedirectToAction("Index", "Home");

            if (usuario.Rol == "Cliente" || User.IsInRole("Cliente"))
                return RedirectToAction("Index", "ClienteHome");

            // 3) Fallback
            return RedirectToAction("Index", "Landing");
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
    }
}