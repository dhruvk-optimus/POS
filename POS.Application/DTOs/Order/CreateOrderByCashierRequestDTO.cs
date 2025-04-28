using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Application.DTOs.OrderItem;

namespace POS.Application.DTOs.Order
{
    public class CreateOrderByCashierRequestDTO
    {
        public string email = null!;
        public IEnumerable<CreateOrderItemRequestDTO> orderItems = null!;
    }
}
