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

            modelBuilder.Entity<Raza>().HasData(
                new Raza
                {
                    Id = 1,
                    Nombre = "San bernardo"
                },
                new Raza
                {
                    Id = 2,
                    Nombre = "Labrador retriever"
                },
                new Raza
                {
                    Id = 3,
                    Nombre = "Gato persa"
                },
                new Raza
                {
                    Id = 4,
                    Nombre = "Gato siamés"
                }
            );

            modelBuilder.Entity<Refugio>().HasData(
                new Refugio
                {
                    Id = 1,
                    Nombre = "Santuario animal",
                    RazonSocial = "Santuario animal S.A.",
                    NombreDelResponsable = "Jorge",
                    ApellidoDelResponsable = "Pérez"
                }
            );
        }

        public DbSet<Raza> Razas { get; set; }
        public DbSet<Refugio> Refugios { get; set; }
        public DbSet<Animal> Animales { get; set; }
    }
}
