using Microsoft.EntityFrameworkCore;
using POS.Application.Interfaces.Repositories;
using POS.Domain.Entities;
using POS.Persistence.Data;

namespace POS.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly POSDbContext _context;

        public OrderRepository(POSDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<OrderEntity>> GetAllAsync()
        {

            IEnumerable<OrderEntity> orders = await _context.Orders
                .Include(o => o.User)
                .ToListAsync();

            return orders;
        }

        public async Task<IEnumerable<OrderEntity>> GetAllByUserAsync(Guid UserId)
        {
            IEnumerable<OrderEntity> orders = await _context.Orders
                .Include(o => o.User)
                .Where(o => o.UserId == UserId)
                .ToListAsync();
            return orders;
        }

        public async Task<OrderEntity?> GetAsync(Guid OrderId)
        {
            OrderEntity? order = await _context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Item)
                .FirstOrDefaultAsync(order => order.OrderId == OrderId);

            return order;

        }


        public async Task AddAsync (OrderEntity order)
        {
            await _context.AddAsync(order);

        }

        public async Task UpdateAsync(OrderEntity order)
        {
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
        }
    }
}
