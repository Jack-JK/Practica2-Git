using PracticoSI1.Models;

namespace PracticoSI1.Business.Contracts
{
    public interface IUsuarioRepository
    {
        Task<Usuario> GetNombreUsuario(string nombreusuario);
    }
}
