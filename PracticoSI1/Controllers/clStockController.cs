using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PracticoSI1.Models;
using PracticoSI1.Services.Contracts;

namespace PracticoSI1.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class clStockController :ControllerBase
    {
        private readonly IclStockService _IclStockService;
        public clStockController(IclStockService iTemp)
        {
            this._IclStockService = iTemp;
        }
        [Authorize]
        [HttpGet]
        public async Task<List<clStock>> GetList()
        {
            return await _IclStockService.GetList();
        }
        [HttpPost("AgregaActualiza")]
        public async Task<clStock> AgregaActualiza(clStock l, string t)
        {
            return await _IclStockService.AgregaActualiza(l, t);
        }
        [HttpDelete("Eliminar")]
        public async Task<int> Eliminar(clStock l)
        {
            // Llama al método en el servicio para realizar la eliminación
            return await _IclStockService.EliminarRegistro(l);
        }
    }
}
