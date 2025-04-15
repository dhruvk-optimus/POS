using MediatR;
using POS.Application.DTOs.Item;

namespace POS.Application.Features.Item.Queries
{
    public record GetItemByIdQuery(Guid ItemId) : IRequest<ItemResponseDTO>;
}
