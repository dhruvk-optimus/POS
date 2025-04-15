using MediatR;

namespace POS.Application.Features.Item.Commands
{
    public record DeleteItemCommand(Guid ItemId) : IRequest<Unit>;
}
