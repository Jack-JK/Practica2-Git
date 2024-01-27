using System.ComponentModel.DataAnnotations;

namespace PracticoSI1.Models
{
    public class clStock
    {
        [Key]
        public int IdStock { get; set; }
        public int Cantidad { get; set; }
        public int IdInsumo { get; set; }
        public int IdAlmacen { get; set; }
        public int IdIngreso { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string EstadoRegistra { get; set; }
    }
}
