using PracticoSI1.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PracticoSI1.Business.Contracts
{
    public interface IclUnidadDeMedidaRepository
    {
        Task<List<clUnidadDeMedida>> GetList();
        Task<int> Elimina(clUnidadDeMedida l);
        Task<clUnidadDeMedida> AgregaActualiza(clUnidadDeMedida l, string t);

    }
}
