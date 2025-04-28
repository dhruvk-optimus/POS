using POS.Domain.Entities;

namespace POS.Application.Interfaces.Repositories
{
    public interface IItemRepository
    {
        Task<IEnumerable<ItemEntity>> GetAllItemsAsync();
        Task<ItemEntity?> GetItemByIdAsync(Guid itemId);
        Task<ItemEntity> AddItemAsync(ItemEntity item);
        Task<ItemEntity> UpdateItemAsync(ItemEntity item);
        Task DeleteItemAsync(ItemEntity item);

        //Task UpdateItemStock(Guid itemId, int quantity);
    }
}
