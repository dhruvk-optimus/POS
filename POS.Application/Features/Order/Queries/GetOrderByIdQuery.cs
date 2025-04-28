using MediatR;
using POS.Application.DTOs.Order;
using POS.Domain.Enums;

namespace POS.Application.Features.Order.Queries
{
    public record GetOrderByIdQuery (Guid OrderId, Guid UserId, UserRole Role): IRequest<OrderDetailsDTO>;
    
}
