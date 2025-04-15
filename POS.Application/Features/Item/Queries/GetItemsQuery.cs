using MediatR;
using POS.Application.DTOs.Item;

namespace POS.Application.Features.Item.Queries
{
    public record GetItemsQuery : IRequest<IEnumerable<ItemResponseDTO>>;
}
