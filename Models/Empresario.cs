using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventosEmpresaApi.Models
{
    [Table("empresario")] // 👈 Asegura el nombre en minúscula
    public class Empresario
    {
        [Key]
        public int IdEmpresario { get; set; }
        public string? NombreEmpresario { get; set; }
        public string? ApellidoEmpresario { get; set; }
        public string? CedulaEmpresario { get; set; }
        public DateTime FechaRegistro { get; set; }
        public bool PlatinoOSuperior { get; set; }
        public bool Esmeralda { get; set; }
        public bool Diamante { get; set; }
        public string? Email { get; set; }
    }
}
