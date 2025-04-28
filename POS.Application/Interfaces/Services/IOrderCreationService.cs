using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Application.DTOs.Order;
using POS.Application.DTOs.OrderItem;
using POS.Domain.Entities;

namespace POS.Application.Interfaces.Services
{
    public interface IOrderCreationService
    {
        Task<OrderEntity> CreateOrderAsync(Guid userId, List<CreateOrderItemRequestDTO> orderItems);
    }
}
