using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TP_Principal_G4.Entities
{
    public class Animal
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [StringLength(10)]
        public string Genero { get; set; } = string.Empty;
        public int Peso { get; set; }
        public int Altura { get; set; }

        [StringLength(200)]
        public string Descripcion { get; set; } = string.Empty;

        [StringLength(20)]
        public string Color { get; set; } = string.Empty;

        [StringLength(20)]
        public string Especie { get; set; } = string.Empty;
        public int Edad { get; set; }
        public DateTime? FechaDeIngreso { get; set; }
        public int Id_Raza { get; set; }
        public int Id_Refugio { get; set; }

        [ForeignKey(nameof(Id_Raza))]
        public Raza Raza { get; set; } = null!;

        [ForeignKey(nameof(Id_Refugio))]
        public Refugio Refugio { get; set; } = null!;
    }
}
