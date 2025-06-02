namespace EventosEmpresaApi.Dtos
{
    public class EventoCreateDto
    {
        public DateTime FechaEvento { get; set; }
        public int IdTipoEvento { get; set; }
        public double CostoEventoEmpresario { get; set; }
    }
}
