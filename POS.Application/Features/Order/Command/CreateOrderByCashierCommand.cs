using MediatR;
using POS.Application.DTOs.Order;
using POS.Application.DTOs.OrderItem;

namespace POS.Application.Features.Order.Command
{
    public record CreateOrderByCashierCommand(string email, IEnumerable<CreateOrderItemRequestDTO> orderItems) : IRequest<OrderDetailsDTO>;

}
