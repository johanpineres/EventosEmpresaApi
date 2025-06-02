using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventosEmpresaApi.Models
{
    [Table("evento")]
    public class Evento
    {
        [Key]
        [Column("idevento")]
        public int IdEvento { get; set; }

        [Column("idtipoevento")]
        public int IdTipoEvento { get; set; }

        [Column("fechaevento")]
        public DateTime FechaEvento { get; set; }

        [Column("costoeventoempresario")]
        public double CostoEventoEmpresario { get; set; }

        [Column("nombreorador")]
        public string? NombreOrador { get; set; }

        [Column("nivelorador")]
        public string? NivelOrador { get; set; }
    }
}
