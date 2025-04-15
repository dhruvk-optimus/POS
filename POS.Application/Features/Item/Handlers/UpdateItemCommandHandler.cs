using System.Net;
using AutoMapper;
using MediatR;
using POS.Application.DTOs.Item;
using POS.Application.Exceptions;
using POS.Application.Features.Item.Commands;
using POS.Application.Interfaces.Repositories;

namespace POS.Application.Features.Item.Handlers
{
    public class UpdateItemCommandHandler : IRequestHandler<UpdateItemCommand, ItemResponseDTO>
    {
        private readonly IItemRepository _itemRepository;
        private readonly IMapper _mapper;

        public UpdateItemCommandHandler(IItemRepository itemRepository, IMapper mapper)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
        }

        public async Task<ItemResponseDTO> Handle(UpdateItemCommand request, CancellationToken cancellationToken)
        {
            // Fetch item by ID
            var itemEntity = await _itemRepository.GetItemByIdAsync(request.Item.ItemId);

            if (itemEntity == null)
            {
                throw new ApiException("Item not found", HttpStatusCode.NotFound);
            }


            // Map updated details from DTO
            itemEntity.Name = request.Item.Name;
            itemEntity.Price = request.Item.Price;
            itemEntity.AvailableStock = request.Item.AvailableStock;

            // Update item in the repository
            var updatedItem = await _itemRepository.UpdateItemAsync(itemEntity);

            // Return updated item
            return _mapper.Map<ItemResponseDTO>(updatedItem);
        }
    }
}
