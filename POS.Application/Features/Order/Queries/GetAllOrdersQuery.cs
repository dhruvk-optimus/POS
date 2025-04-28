using MediatR;
using POS.Application.DTOs.Order;

namespace POS.Application.Features.Order.Queries
{
    public record GetAllOrdersQuery : IRequest<IEnumerable<OrderDTO>>;
    
}
