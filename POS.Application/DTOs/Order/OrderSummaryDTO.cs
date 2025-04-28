using POS.Domain.Enums;

namespace POS.Application.DTOs.Order
{
    public class OrderSummaryDTO
    {
         
            public Guid OrderId { get; set; }
            public OrderStatus Status { get; set; }
            public double TotalAmount { get; set; }
            public DateTime OrderDate { get; set; }
       
    }
}
