using Prueba21.Models;

namespace Prueba21.Service.Interfaces
{
    public interface IAuthService
    {
        Task<Personal?> ValidarUsuario(string email, string contrasenia);
    }
}