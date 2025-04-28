using POS.Application.DTOs.OrderItem;
using POS.Domain.Enums;

namespace POS.Application.DTOs.Order
{
    public class OrderDetailsDTO
    {
        public Guid OrderId { get; set; }
        public OrderStatus Status { get; set; }
        public double TotalAmount { get; set; }
        public DateTime OrderDate { get; set; }

        public IEnumerable<OrderItemDTO> orderItems { get; set; } = null!;
    }
}
