using TP_Principal_G4.DTOs;
using TP_Principal_G4.Entities;

namespace TP_Principal_G4.Repositories.Contracts
{
    public interface IAnimalRepository : IRepository<Animal, int>
    {
        Task<ShowAnimalDTO> GetAnimal(int id);
        Task<IEnumerable<ShowAnimalDTO>> GetAllAnimals();
        Task<IEnumerable<Raza>> GetAllRazas();
    }
}
