using PracticoSI1.Business.Contracts;
using PracticoSI1.Models;
using PracticoSI1.Services.Contracts;

namespace PracticoSI1.Services.Clases
{
    public class cIGrupoArticuloService : IcIGrupoArticuloService
    {
        private readonly IcIGrupoArticuloRepository _IcIGrupoArticuloRepository;
        public cIGrupoArticuloService(IcIGrupoArticuloRepository temp2)
        {
            _IcIGrupoArticuloRepository = temp2;
        }
        public Task<List<cIGrupoArticulo>> GetList()
        {
            return _IcIGrupoArticuloRepository.GetList();
        }
        public Task<cIGrupoArticulo> AgregaActualiza(cIGrupoArticulo l, string t)
        {
            return _IcIGrupoArticuloRepository.AgregaActualiza(l, t);
        }
        public Task<int> Elimina(cIGrupoArticulo l)
        {
            return _IcIGrupoArticuloRepository.Elimina(l);
        }
    }
}
