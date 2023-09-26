using System.ComponentModel.DataAnnotations;

namespace TP_Principal_G4.DTOs
{
    public class AnimalDTO
    {
        [Required(ErrorMessage = "El campo 'Nombre' es obligatorio.")]
        [MaxLength(100, ErrorMessage = "Máximo 100 caracteres.")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "El campo 'Género' es obligatorio.")]
        [MaxLength(10, ErrorMessage = "Máximo 10 caracteres.")]
        public string Genero { get; set; } = string.Empty;

        [Required(ErrorMessage = "El campo 'Peso' es obligatorio.")]
        [Range(1, 100, ErrorMessage = "El peso debe estar entre 1 y 100 kg.")]
        public int Peso { get; set; }

        [Required(ErrorMessage = "El campo 'Altura' es obligatorio.")]
        [Range(1, 100, ErrorMessage = "La altura debe estar entre 1 y 100 centímetros.")]
        public int Altura { get; set; }

        [MaxLength(200, ErrorMessage = "Máximo 200 caracteres.")]
        public string Descripcion { get; set; } = string.Empty;

        [Required(ErrorMessage = "El campo 'Color' es obligatorio.")]
        [MaxLength(20, ErrorMessage = "Máximo 20 caracteres.")]
        public string Color { get; set; } = string.Empty;

        [Required(ErrorMessage = "El campo 'Especie' es obligatorio.")]
        [MaxLength(20, ErrorMessage = "Máximo 20 caracteres.")]
        public string Especie { get; set; } = string.Empty;

        [Required(ErrorMessage = "El campo 'Edad' es obligatorio.")]
        public int Edad { get; set; }

        [Required(ErrorMessage = "El campo 'FechaDeIngreso' es obligatorio.")]
        public DateTime FechaDeIngreso { get; set; }

        [Required(ErrorMessage = "El campo 'Id_Raza' es obligatorio.")]
        public int Id_Raza { get; set; }

        [Required(ErrorMessage = "El campo 'Id_Refugio' es obligatorio.")]
        public int Id_Refugio { get; set; }
    }
}
