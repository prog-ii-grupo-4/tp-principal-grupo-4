using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using TP_Principal_G4.Validations;

namespace TP_Principal_G4.DTOs
{
    public class AnimalDTO
    {
        [Required(ErrorMessage = AnimalValidation.REQUIRED_MESSAGE)]
        [MaxLength(AnimalValidation.MAX_LENGTH_NOMBRE, ErrorMessage = AnimalValidation.MAX_LENGTH_NOMBRE_MESSAGE)]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = AnimalValidation.REQUIRED_MESSAGE)]
        [RegularExpression(AnimalValidation.REGEX_GENERO, ErrorMessage = AnimalValidation.GENERO_NOT_VALID)]
        public string Genero { get; set; } = string.Empty;

        [Required(ErrorMessage = AnimalValidation.REQUIRED_MESSAGE)]
        [Range(AnimalValidation.MIN_RANGE_PESO, AnimalValidation.MAX_RANGE_PESO, ErrorMessage = AnimalValidation.RANGE_PESO_MESSAGE)]
        public int Peso { get; set; }

        [Required(ErrorMessage = AnimalValidation.REQUIRED_MESSAGE)]
        [Range(AnimalValidation.MIN_RANGE_ALTURA, AnimalValidation.MAX_RANGE_ALTURA, ErrorMessage = AnimalValidation.RANGE_ALTURA_MESSAGE)]
        public int Altura { get; set; }

        [MaxLength(AnimalValidation.MAX_LENGTH_DESCRIPCION, ErrorMessage = AnimalValidation.MAX_LENGTH_DESCRIPCION_MESSAGE)]
        public string Descripcion { get; set; } = string.Empty;

        [Required(ErrorMessage = AnimalValidation.REQUIRED_MESSAGE)]
        [MaxLength(AnimalValidation.MAX_LENGTH_COLOR, ErrorMessage = AnimalValidation.MAX_LENGTH_COLOR_MESSAGE)]
        public string Color { get; set; } = string.Empty;

        [Required(ErrorMessage = AnimalValidation.REQUIRED_MESSAGE)]
        [MaxLength(AnimalValidation.MAX_LENGTH_ESPECIE, ErrorMessage = AnimalValidation.MAX_LENGTH_ESPECIE_MESSAGE)]
        public string Especie { get; set; } = string.Empty;

        [Required(ErrorMessage = AnimalValidation.REQUIRED_MESSAGE)]
        [Range(0, int.MaxValue, ErrorMessage = AnimalValidation.NUMBER_NOT_VALID)]
        public int Edad { get; set; }

        [Required(ErrorMessage = AnimalValidation.REQUIRED_MESSAGE)]
        public DateTime? FechaDeIngreso { get; set; }

        [Required(ErrorMessage = AnimalValidation.REQUIRED_MESSAGE)]
        public int Id_Raza { get; set; }

        [Required(ErrorMessage = AnimalValidation.REQUIRED_MESSAGE)]
        public int Id_Refugio { get; set; }
    }
}
