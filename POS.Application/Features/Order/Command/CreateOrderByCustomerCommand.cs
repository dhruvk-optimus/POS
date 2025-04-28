using MediatR;
using POS.Application.DTOs.Order;
using POS.Application.DTOs.OrderItem;

namespace POS.Application.Features.Order.Command
{
    public record CreateOrderByCustomerCommand(Guid userId, IEnumerable<CreateOrderItemRequestDTO> orderItems) : IRequest<OrderDetailsDTO>;
}
