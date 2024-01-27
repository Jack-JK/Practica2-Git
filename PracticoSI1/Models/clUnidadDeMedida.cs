using System;
using System.ComponentModel.DataAnnotations;

namespace PracticoSI1.Models
{
    public class clUnidadDeMedida
    {
        [Key]
        public int IdUnidadDeMedida { get; set; }
        public string NombreUnidadDeMedida { get; set; }
        public string NombreDeMedida { get; set; }
        public string Abreviacion { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string EstadoRegistro { get; set; }
    }
}
