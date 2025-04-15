using System.Net;
using MediatR;
using POS.Application.Exceptions;
using POS.Application.Features.Item.Commands;
using POS.Application.Interfaces.Repositories;

namespace POS.Application.Features.Item.Handlers
{
    public class DeleteItemCommandHandler : IRequestHandler<DeleteItemCommand, Unit>
    {
        private readonly IItemRepository _itemRepository;

        public DeleteItemCommandHandler(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<Unit> Handle(DeleteItemCommand request, CancellationToken cancellationToken)
        {
            var item = await _itemRepository.GetItemByIdAsync(request.ItemId);

            if (item == null)
                throw new ApiException("Item not found", HttpStatusCode.NotFound);

            await _itemRepository.DeleteItemAsync(item);

            return Unit.Value;
        }
    }
}
