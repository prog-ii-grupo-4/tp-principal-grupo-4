using Microsoft.EntityFrameworkCore;
using TP_Principal_G4.Entities;

namespace TP_Principal_G4
{
    public class TpPrincipalG4Context : DbContext
    {
        public TpPrincipalG4Context(DbContextOptions<TpPrincipalG4Context> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Raza> Razas { get; set; }
        public DbSet<Refugio> Refugios { get; set; }
        public DbSet<Animal> Animales { get; set; }
    }
}
