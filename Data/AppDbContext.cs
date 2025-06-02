using Microsoft.EntityFrameworkCore;
using EventosEmpresaApi.Models;

namespace EventosEmpresaApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Empresario> Empresarios => Set<Empresario>();
        public DbSet<Evento> Eventos => Set<Evento>();
        public DbSet<EmpresarioEvento> EmpresarioEventos => Set<EmpresarioEvento>();
    }
}
