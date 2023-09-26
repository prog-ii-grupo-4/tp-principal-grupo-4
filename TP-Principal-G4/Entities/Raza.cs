namespace TP_Principal_G4.Entities
{
    public class Raza
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;

        public ICollection<Animal> Animales { get; } = new List<Animal>();
    }
}
