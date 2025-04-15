using POS.Domain.Entities;

namespace POS.Application.Interfaces.Repositories
{
    public interface IItemRepository
    {
        Task<ItemEntity> AddItemAsync(ItemEntity item);
        Task<ItemEntity> UpdateItemAsync(ItemEntity item);
        Task DeleteItemAsync(ItemEntity item);
        Task<ItemEntity?> GetItemByIdAsync(Guid itemId);
        Task<IEnumerable<ItemEntity>> GetAllItemsAsync();
    }
}
