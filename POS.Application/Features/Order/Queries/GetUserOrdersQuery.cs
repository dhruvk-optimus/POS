using MediatR;
using POS.Application.DTOs.Order;

namespace POS.Application.Features.Order.Queries
{
    public record GetUserOrdersQuery(Guid UserId) : IRequest<IEnumerable<OrderSummaryDTO>>;
}
