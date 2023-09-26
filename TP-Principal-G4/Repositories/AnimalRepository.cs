using Microsoft.EntityFrameworkCore;
using TP_Principal_G4.DTOs;
using TP_Principal_G4.Entities;
using TP_Principal_G4.Exceptions;
using TP_Principal_G4.Repositories.Contracts;

namespace TP_Principal_G4.Repositories
{
    public class AnimalRepository : IAnimalRepository
    {
        private readonly TpPrincipalG4Context _context;

        public AnimalRepository(TpPrincipalG4Context context) => _context = context;

        public async Task Create(Animal entity)
        {
            if(_context.Animales.Any(a => a.Nombre == entity.Nombre))
            {
                throw new AnimalException("El animal llamado " + entity.Nombre + " ya existe.");
            }

            _context.Animales.Add(entity);
            await Save();
        }

        public async Task Update(Animal entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await Save();
        }

        public async Task Delete(int id)
        {
            Animal? animal = await _context.Animales.FindAsync(id);

            if(animal == null)
                throw new AnimalException("El animal con id " + id + " no existe.");

            _context.Animales.Remove(animal);
            await Save();
        }

        public async Task<Animal?> GetById(int id)
        {
            return await _context.Animales.FindAsync(id);
        }

        public async Task<IEnumerable<Animal>> GetAll()
        {
            List<Animal> animales = await _context.Animales.Include(a => a.Raza).Include(a => a.Refugio).ToListAsync();

            return animales;
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<MostrarAnimalesDTO>> GetAllAnimals()
        {
            IEnumerable<Animal> animales = await this.GetAll();
            List<MostrarAnimalesDTO> mostrarAnimales = new List<MostrarAnimalesDTO>();

            if (animales.Count() > 0)
            {
                
                foreach(var animal in animales)
                {
                    mostrarAnimales.Add(new MostrarAnimalesDTO
                    {
                        Id = animal.Id,
                        Nombre = animal.Nombre,
                        Raza = animal.Raza.Nombre,
                        Genero = animal.Genero,
                        Peso = animal.Peso,
                        Altura = animal.Altura,
                        Color = animal.Color,
                        Descripcion = animal.Descripcion,
                        Edad = animal.Edad,
                        Especie = animal.Especie,
                        FechaDeIngreso = animal.FechaDeIngreso,
                        Refugio = animal.Refugio.Nombre
                    });
                }
            }

            return mostrarAnimales;
        }

        public async Task<IEnumerable<Raza>> GetAllRazas()
        {
            return await _context.Razas.ToListAsync();
        }
    }
}
