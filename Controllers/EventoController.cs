using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EventosEmpresaApi.Data;
using EventosEmpresaApi.Models;
using EventosEmpresaApi.Dtos;


namespace EventosEmpresaApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EventoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEvento(int id)
        {
            var evento = await _context.Eventos.FindAsync(id);
            if (evento == null) return NotFound();

            var empresarios = await _context.EmpresarioEventos
                .Where(e => e.IdEvento == id)
                .Join(_context.Empresarios,
                      ee => ee.IdEmpresario,
                      emp => emp.IdEmpresario,
                      (ee, emp) => emp)
                .ToListAsync();

            return Ok(new { evento, empresarios });
        }

[HttpPost]
public async Task<IActionResult> CrearEvento([FromBody] EventoCreateDto dto)
{
    var evento = new Evento
    {
        FechaEvento = DateTime.SpecifyKind(dto.FechaEvento, DateTimeKind.Utc),
        IdTipoEvento = dto.IdTipoEvento,
        CostoEventoEmpresario = dto.CostoEventoEmpresario
    };

    _context.Eventos.Add(evento);
    await _context.SaveChangesAsync();

    return CreatedAtAction(nameof(GetEvento), new { id = evento.IdEvento }, evento);
}


        [HttpPut("{id}")]
        public async Task<IActionResult> EditarEvento(int id, [FromBody] Evento input)
        {
            var evento = await _context.Eventos.FindAsync(id);
            if (evento == null) return NotFound();

            evento.FechaEvento = input.FechaEvento;
            evento.CostoEventoEmpresario = input.CostoEventoEmpresario;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPost("{id}/empresario/{idEmpresario}")]
        public async Task<IActionResult> AgregarEmpresario(int id, int idEmpresario)
        {
            var yaExiste = await _context.EmpresarioEventos
                .AnyAsync(e => e.IdEvento == id && e.IdEmpresario == idEmpresario);

            if (yaExiste) return Conflict("El empresario ya está inscrito en el evento.");

            var entidad = new EmpresarioEvento
            {
                IdEvento = id,
                IdEmpresario = idEmpresario,
                FechaRegistro = DateTime.UtcNow,
                ValorPagado = 0,
                HoraEvento = DateTime.Now.ToShortTimeString()
            };

            _context.EmpresarioEventos.Add(entidad);
            await _context.SaveChangesAsync();
            return Ok(entidad);
        }

        [HttpDelete("{id}/empresario/{idEmpresario}")]
        public async Task<IActionResult> QuitarEmpresario(int id, int idEmpresario)
        {
            var relacion = await _context.EmpresarioEventos
                .FirstOrDefaultAsync(e => e.IdEvento == id && e.IdEmpresario == idEmpresario);

            if (relacion == null) return NotFound();

            _context.EmpresarioEventos.Remove(relacion);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
