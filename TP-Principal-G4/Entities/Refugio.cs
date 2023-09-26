namespace TP_Principal_G4.Entities
{
    public class Refugio
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string RazonSocial { get; set; } = string.Empty;
        public string NombreDelResponsable { get; set; } = string.Empty;
        public string ApellidoDelResponsable { get; set; } = string.Empty;

        public ICollection<Animal> Animales { get; } = new List<Animal>();
    }
}
