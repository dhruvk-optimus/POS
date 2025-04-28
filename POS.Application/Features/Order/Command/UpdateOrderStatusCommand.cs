using MediatR;
using POS.Application.DTOs.Order;
using POS.Domain.Enums;

namespace POS.Application.Features.Order.Command
{
    public record UpdateOrderStatusCommand (Guid orderId, OrderStatus orderStatus) : IRequest<OrderSummaryDTO>;
}
