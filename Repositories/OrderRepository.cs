using CornerStore.API.Context;
using CornerStore.API.Model;
using CornerStore.API.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace CornerStore.API.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public OrderRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Order> CreateOrder(Order order)
        {
            await _dbContext.Orders.AddAsync(order);
            await _dbContext.SaveChangesAsync();
            return order;
        }

        public async Task<IEnumerable<Order>> GetAllOrders()
        {
            return await _dbContext.Orders.ToListAsync();
        }

        public async Task<Order> GetOrderBtId(Guid id)
        {
            return await _dbContext.Orders.FindAsync(id);
        }

        public async Task UpdateOrder(Order order)
        {
            _dbContext.Orders.Update(order);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteOrder(Guid id)
        {
            var details = await _dbContext.Orders.FindAsync(id);
            if (details != null)
            {
                _dbContext.Remove(details);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
