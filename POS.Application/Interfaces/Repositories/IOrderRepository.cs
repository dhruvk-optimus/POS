using POS.Domain.Entities;

namespace POS.Application.Interfaces.Repositories
{
    public interface IOrderRepository
    {
        Task<IEnumerable<OrderEntity>> GetAllAsync();
        Task<IEnumerable<OrderEntity>> GetAllByUserAsync(Guid UserId);
        Task<OrderEntity?> GetAsync(Guid OrderId);
        Task AddAsync (OrderEntity order);
        Task UpdateAsync (OrderEntity order);

    }
}
