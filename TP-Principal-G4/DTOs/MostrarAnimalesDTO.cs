namespace TP_Principal_G4.DTOs
{
    public class MostrarAnimalesDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Raza { get; set; } = string.Empty;
        public string Genero { get; set; } = string.Empty;
        public int Peso { get; set; }
        public int Altura { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
        public string Especie { get; set; } = string.Empty;
        public int Edad { get; set; }
        public DateTime? FechaDeIngreso { get; set; }
        public string Refugio { get; set; } = string.Empty;
    }
}
