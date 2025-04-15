using MediatR;
using POS.Application.DTOs.Item;
using POS.Application.Interfaces.Repositories;
using POS.Domain.Entities;
using AutoMapper;
using POS.Application.Features.Item.Commands;

namespace POS.Application.Features.Item.Handlers
{
    public class AddItemCommandHandler : IRequestHandler<AddItemCommand, ItemResponseDTO>
    {
        private readonly IItemRepository _itemRepository;
        private readonly IMapper _mapper;

        public AddItemCommandHandler(IItemRepository itemRepository, IMapper mapper)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
        }

        public async Task<ItemResponseDTO> Handle(AddItemCommand request, CancellationToken cancellationToken)
        {
            // Map DTO to entity
            var itemEntity = _mapper.Map<ItemEntity>(request.Item);

            // Add item to the repository
            var createdItem = await _itemRepository.AddItemAsync(itemEntity);

            // Return mapped response DTO
            return _mapper.Map<ItemResponseDTO>(createdItem);
        }
    }
}
