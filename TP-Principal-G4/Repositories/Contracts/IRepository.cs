namespace TP_Principal_G4.Repositories.Contracts
{
    public interface IRepository<T, K> where T : class where K : struct
    {
        Task<T?> GetById(K id);
        Task<IEnumerable<T>> GetAll();
        Task Create(T entity);
        Task Update(T entity);
        Task Delete(K id);
        Task Save();
    }
}
