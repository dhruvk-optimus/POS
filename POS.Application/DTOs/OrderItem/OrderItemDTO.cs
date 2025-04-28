using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Application.DTOs.OrderItem
{
    public class OrderItemDTO
    {

        public Guid OrderItemId { get; set; }

        public int Quantity { get; set; }
        public int UnitPrice { get; set; }

        public string ItemName { get; set; } = null!;
    }
}
