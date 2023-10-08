using Microsoft.EntityFrameworkCore;
using TP_Principal_G4.Entities;
using TP_Principal_G4.Repositories.Contracts;

namespace TP_Principal_G4.Repositories
{
    public class RefugioRepository : IRefugioRepository
    {
        private readonly TpPrincipalG4Context _context;

        public RefugioRepository(TpPrincipalG4Context context) => _context = context;

        public Task Create(Refugio entity)
        {
            throw new NotImplementedException();
        }
        public Task Update(Refugio entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Refugio>> GetAll()
        {
            return await _context.Refugios.ToListAsync();
        }

        public Task<Refugio?> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
