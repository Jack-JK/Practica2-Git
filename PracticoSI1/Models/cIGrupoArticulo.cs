using System.ComponentModel.DataAnnotations;

namespace PracticoSI1.Models
{
    public class cIGrupoArticulo
    {
        [Key]
        public int IdGrupoArticulo { get; set; }
        public string NombreGrupoArticulo { get; set; }
        public string Abreviatura { get; set; }
        public int IdPadre { get; set; }
        public int IdPartida { get; set; }
        public int Nivel { get; set; }
        public string Sector { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string EstadoRegistro { get; set; }

    }
}
