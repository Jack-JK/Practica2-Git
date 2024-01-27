using PracticoSI1.Models;

namespace PracticoSI1.Business.Contracts
{
    public interface IclStockRepository
    {
        Task<List<clStock>> GetList();
        Task<clStock> AgregaActualiza(clStock l, string t);
        Task<int> EliminarRegistro(clStock l);
    }
}
