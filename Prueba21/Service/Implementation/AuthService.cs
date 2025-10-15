using Microsoft.EntityFrameworkCore;
using Prueba21.Data;
using Prueba21.Models;
using Prueba21.Service.Interfaces;

namespace Prueba21.Service.Implementation
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _context;

        public AuthService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Personal?> ValidarUsuario(string email, string contrasenia)
        {
            return await _context.Personal
                .FirstOrDefaultAsync(x => x.Email == email && x.Contrasenia == contrasenia);
        }
    }
}