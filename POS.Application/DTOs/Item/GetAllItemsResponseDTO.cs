using POS.Domain.Entities;

namespace POS.Application.DTOs.Item
{
    public class GetAllItemsResponseDTO
    {
        public IEnumerable<ItemEntity> Items { get; set; } = null!;

    }
}
