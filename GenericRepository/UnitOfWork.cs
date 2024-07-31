using CornerStore.API.Context;
using Microsoft.EntityFrameworkCore;

namespace CornerStore.API.GenericRepository
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await SaveChanges();
            return entity;
        }

        public async Task<List<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetById(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<T> Update(T entity)
        {
            _context.Update(entity);
            await SaveChanges();
            return entity;
        }

        public async Task<T> Delete(Guid id)
        {
           var deleteId = _dbSet.FindAsync(id);
           _dbSet.Remove(deleteId.Result);
            await  SaveChanges();
            return deleteId.Result;
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
      
    }
}
