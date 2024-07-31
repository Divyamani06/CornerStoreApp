
namespace CornerStore.API.GenericRepository
{
    public interface IUnitOfWork<T> where T : class
    {
        Task<T> AddAsync(T entity);
        Task<T> Delete(Guid id);
        Task<List<T>> GetAll();
        Task<T> GetById(Guid id);
        Task SaveChanges();
        Task<T> Update(T entity);
    }
}