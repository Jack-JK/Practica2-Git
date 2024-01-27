using PracticoSI1.Models;

namespace PracticoSI1.Services.Contracts
{
    public interface IUsuarioService
    {
        Task<Usuario> GetNombreUsuario(string nombreusuario);
        string CrearPasswordHash(string password, string salt);
        string GenerarToken(DateTime currentDate, Usuario usuario, TimeSpan expirationTime, string? signingKey, string? audience, string? issuer);
    }
}
