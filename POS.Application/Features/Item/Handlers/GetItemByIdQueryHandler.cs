using AutoMapper;
using MediatR;
using POS.Application.DTOs.Item;
using POS.Application.Exceptions;
using POS.Application.Interfaces.Repositories;

namespace POS.Application.Features.Item.Queries
{
    public class GetItemByIdQueryHandler : IRequestHandler<GetItemByIdQuery, ItemResponseDTO>
    {
        private readonly IItemRepository _itemRepository;
        private readonly IMapper _mapper;

        public GetItemByIdQueryHandler(IItemRepository itemRepository, IMapper mapper)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
        }

        public async Task<ItemResponseDTO> Handle(GetItemByIdQuery request, CancellationToken cancellationToken)
        {
            var item = await _itemRepository.GetItemByIdAsync(request.ItemId);

            if (item == null)
                throw new ApiException("Item not found.", System.Net.HttpStatusCode.NotFound);

            return _mapper.Map<ItemResponseDTO>(item);
        }
    }
}
