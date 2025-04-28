namespace POS.Application.DTOs.OrderItem
{
    public class CreateOrderItemRequestDTO
    {
        public Guid ItemId { get; set; }
        public int Quantity { get; set; }
    }
}
