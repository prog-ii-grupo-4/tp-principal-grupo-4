using System.Linq.Expressions;
using TP_Principal_G4.DTOs;
using TP_Principal_G4.Entities;

namespace TP_Principal_G4.Repositories.Contracts
{
    public interface IAnimalRepository : IRepository<Animal, int>
    {
        Task<ShowAnimalDTO> GetAnimal(int id);
        Task<IEnumerable<ShowAnimalDTO>> GetAllAnimales();
        Task<IEnumerable<Raza>> GetAllRazas();
        Task<IEnumerable<ShowAnimalDTO>> SearchAnimalesBy(string? color, string? especie);
    }
}
