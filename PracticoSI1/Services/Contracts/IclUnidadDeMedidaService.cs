using PracticoSI1.Models;
using PracticoSI1.Service.Clases;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PracticoSI1.Service.Contracts
{
    public interface IclUnidadDeMedidaService
    {
        Task<List<clUnidadDeMedida>> GetList();
        Task<clUnidadDeMedida> AgregaActualiza(clUnidadDeMedida l, string t);
        Task<int> Elimina(clUnidadDeMedida l);
    }
}
