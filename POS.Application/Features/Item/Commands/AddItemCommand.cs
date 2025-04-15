using MediatR;
using POS.Application.DTOs.Item;

namespace POS.Application.Features.Item.Commands
{
    public record AddItemCommand(AddItemRequestDTO Item) : IRequest<ItemResponseDTO>;
}
