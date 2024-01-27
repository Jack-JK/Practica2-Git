using Microsoft.AspNetCore.Mvc;
using PracticoSI1.Models;
using PracticoSI1.Service.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PracticoSI1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class clUnidadDeMedidaController
    {

        private readonly IclUnidadDeMedidaService _IclUnidadDeMedidaService;
        public clUnidadDeMedidaController(IclUnidadDeMedidaService iTemp)
        {
            this._IclUnidadDeMedidaService = iTemp;
        }
        [HttpGet]
        public async Task<List<clUnidadDeMedida>> GetList()
        {
            return await _IclUnidadDeMedidaService.GetList();
        }
        [HttpPost("AgregaActualiza")]
        public async Task<clUnidadDeMedida> AgregaActualiza(clUnidadDeMedida l, string t)
        {
            return await _IclUnidadDeMedidaService.AgregaActualiza(l, t);
        }

        [HttpDelete("Eliminar")]
        public async Task<int> Eliminar(clUnidadDeMedida l)
        {
            // Llama al método en el servicio para realizar la eliminación
            return await _IclUnidadDeMedidaService.Elimina(l);
        }


    }
}
