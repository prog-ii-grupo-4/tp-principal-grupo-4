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
            if(await CheckIfNombreExists(entity.Nombre))
                throw new AnimalException("El animal llamado " + entity.Nombre + " ya existe.");

            if(!await CheckIfRazaExists(entity.Id_Raza))
                throw new AnimalException("La raza no existe.");

            if (!await CheckIfRefugioExists(entity.Id_Refugio))
                throw new AnimalException("El refugio no existe.");

            _context.Animales.Add(entity);
            await Save();
        }

        public async Task Update(Animal entity)
        {
            if (await _context.Animales.AnyAsync(a => a.Nombre.Equals(entity.Nombre) && !a.Id.Equals(entity.Id)))
                throw new AnimalException("El animal llamado " + entity.Nombre + " ya existe.");

            if (!await CheckIfRazaExists(entity.Id_Raza))
                throw new AnimalException("La raza no existe.");

            if (!await CheckIfRefugioExists(entity.Id_Refugio))
                throw new AnimalException("El refugio no existe.");

            _context.Animales.Update(entity);
            await Save();
        }

        public async Task Delete(int id)
        {
            Animal? animal = await GetById(id);

            if(animal != null)
            {
                _context.Animales.Remove(animal);
                await Save();
            }
        }

        public async Task<Animal?> GetById(int id)
        {
            return await _context.Animales.FindAsync(id);
        }

        public async Task<ShowAnimalDTO> GetAnimal(int id)
        {
            Animal? animal = await _context.Animales.Include(a => a.Raza).Include(a => a.Refugio).FirstOrDefaultAsync(a => a.Id.Equals(id));

            if (animal != null)
            {
                return new ShowAnimalDTO()
                {
                    Id = id,
                    Nombre = animal.Nombre,
                    Raza = animal.Raza.Nombre,
                    Genero = animal.Genero,
                    Peso = animal.Peso,
                    Altura = animal.Altura,
                    Descripcion = animal.Descripcion,
                    Color = animal.Color,
                    Edad = animal.Edad,
                    Especie = animal.Especie,
                    FechaDeIngreso = animal.FechaDeIngreso,
                    Refugio = animal.Refugio.Nombre
                };
            }

            return null!;
        }

        public async Task<IEnumerable<Animal>> GetAll()
        {
            List<Animal> animales = await _context.Animales.Include(a => a.Raza).Include(a => a.Refugio).ToListAsync();

            return animales;
        }

        public async Task<IEnumerable<ShowAnimalDTO>> SearchAnimalesBy(string? color, string? especie)
        {
            IQueryable<Animal> query = _context.Animales;

            if (!string.IsNullOrEmpty(color))
                query = query.Where(a => a.Color.Contains(color.Trim()));

            if (!string.IsNullOrEmpty(especie))
                query = query.Where(a => a.Especie.Contains(especie.Trim()));

            List<Animal> animales = await query.Include(a => a.Raza).Include(a => a.Refugio).ToListAsync();
            List<ShowAnimalDTO> animalesDTO = new List<ShowAnimalDTO>();

            foreach(Animal animal in animales)
            {
                animalesDTO.Add(new ShowAnimalDTO()
                {
                    Id = animal.Id,
                    Nombre = animal.Nombre,
                    Raza = animal.Raza.Nombre,
                    Genero = animal.Genero,
                    Peso = animal.Peso,
                    Altura = animal.Altura,
                    Color = animal.Color,
                    Edad = animal.Edad,
                    Especie = animal.Especie,
                    Descripcion = animal.Descripcion,
                    FechaDeIngreso = animal.FechaDeIngreso,
                    Refugio = animal.Refugio.Nombre
                });
            }

            return animalesDTO;
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ShowAnimalDTO>> GetAllAnimales()
        {
            IEnumerable<Animal> animales = await this.GetAll();
            List<ShowAnimalDTO> mostrarAnimales = new List<ShowAnimalDTO>();

            if (animales.Count() > 0)
            {
                
                foreach(var animal in animales)
                {
                    mostrarAnimales.Add(new ShowAnimalDTO
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

        private async Task<bool> CheckIfNombreExists(string nombre)
        {
            return await _context.Animales.AnyAsync(a => a.Nombre == nombre);
        }

        private async Task<bool> CheckIfRazaExists(int razaId)
        {
            return await _context.Razas.AnyAsync(r => r.Id == razaId);
        }

        private async Task<bool> CheckIfRefugioExists(int refugioId)
        {
            return await _context.Refugios.AnyAsync(r => r.Id == refugioId);
        }
    }
}
