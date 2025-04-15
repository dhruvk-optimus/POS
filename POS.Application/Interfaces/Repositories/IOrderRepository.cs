using POS.Domain.Entities;

namespace POS.Application.Interfaces.Repositories
{
    public interface IOrderRepository
    {
        Task<IEnumerable<OrderEntity>> GetAllAsync();
        

    }
}
