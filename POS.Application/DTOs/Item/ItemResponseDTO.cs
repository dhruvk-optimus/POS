namespace POS.Application.DTOs.Item
{
    public class ItemResponseDTO
    {
        public Guid ItemId { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int AvailableStock { get; set; }
    }
}
