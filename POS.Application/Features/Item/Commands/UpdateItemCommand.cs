using MediatR;
using POS.Application.DTOs.Item;

namespace POS.Application.Features.Item.Commands
{
    public record UpdateItemCommand(UpdateItemRequestDTO Item) : IRequest<ItemResponseDTO>;
}
