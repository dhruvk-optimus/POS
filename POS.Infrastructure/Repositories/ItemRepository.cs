using POS.Application.Interfaces.Repositories;
using POS.Domain.Entities;
using POS.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace POS.Infrastructure.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly POSDbContext _context;

        public ItemRepository(POSDbContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<ItemEntity>> GetAllItemsAsync()
        {
            return await _context.Items.ToListAsync();
        }

        public async Task<ItemEntity?> GetItemByIdAsync(Guid itemId)
        {
            return await _context.Items.FindAsync(itemId);
        }
        

        public async Task<ItemEntity> AddItemAsync(ItemEntity item)
        {
            _context.Items.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<ItemEntity> UpdateItemAsync(ItemEntity item)
        {
            _context.Items.Update(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task DeleteItemAsync(ItemEntity item)
        {
            _context.Items.Remove(item);
            await _context.SaveChangesAsync();
        }


    }
}
