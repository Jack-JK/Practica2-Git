using PracticoSI1.Models;

namespace PracticoSI1.Services.Contracts
{
    public interface IcIGrupoArticuloService
    {
        Task<List<cIGrupoArticulo>> GetList();
        Task<cIGrupoArticulo> AgregaActualiza(cIGrupoArticulo l, string t);
        Task<int> Elimina(cIGrupoArticulo l);
    }
}
