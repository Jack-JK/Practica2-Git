using PracticoSI1.Models;

namespace PracticoSI1.Business.Contracts
{
    public interface IcIGrupoArticuloRepository
    {
        Task<List<cIGrupoArticulo>> GetList();
        Task<cIGrupoArticulo> AgregaActualiza(cIGrupoArticulo l, string t);
        Task<int> Elimina(cIGrupoArticulo l);
    }
}
