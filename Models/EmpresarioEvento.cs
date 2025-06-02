using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventosEmpresaApi.Models
{
    [Table("empresarioevento")] // 👈 Asegura el nombre en minúscula
    public class EmpresarioEvento
    {
        [Key]
        public int IdEmpresarioEvento { get; set; }
        public int IdEmpresario { get; set; }
        public int IdEvento { get; set; }
        public DateTime FechaRegistro { get; set; }
        public double ValorPagado { get; set; }
        public string? HoraEvento { get; set; }
    }
}
