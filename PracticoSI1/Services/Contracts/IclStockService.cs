using PracticoSI1.Models;

namespace PracticoSI1.Services.Contracts
{
    public interface IclStockService
    {
        Task<List<clStock>> GetList();
        Task<clStock> AgregaActualiza(clStock l, string t);
        Task<int> EliminarRegistro(clStock l);

    }
}
