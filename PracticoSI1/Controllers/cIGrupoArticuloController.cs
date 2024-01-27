using Microsoft.AspNetCore.Mvc;
using PracticoSI1.Models;
using PracticoSI1.Services.Clases;
using PracticoSI1.Services.Contracts;

namespace PracticoSI1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class cIGrupoArticuloController : ControllerBase
    {
        private readonly IcIGrupoArticuloService _IcIGrupoArticuloService;

        public cIGrupoArticuloController(IcIGrupoArticuloService itemp)
        {
            this._IcIGrupoArticuloService = itemp;
        }
        [HttpGet]
        public async Task<List<cIGrupoArticulo>> GetList()
        {
            return await _IcIGrupoArticuloService.GetList();
        }
        [HttpPost("AgregaActualiza")]
        public async Task<cIGrupoArticulo> AgregaActualiza(cIGrupoArticulo l, string t)
        {
            return await _IcIGrupoArticuloService.AgregaActualiza(l, t);
        }
        [HttpDelete("Eliminar")]
        public async Task<int> Eliminar(cIGrupoArticulo l)
        {
            // Llama al método en el servicio para realizar la eliminación
            return await _IcIGrupoArticuloService.Elimina(l);
        }
    }
}
