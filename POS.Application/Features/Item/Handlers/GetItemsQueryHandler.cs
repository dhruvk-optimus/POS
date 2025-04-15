using MediatR;

using POS.Application.Interfaces.Repositories;
using AutoMapper;
using POS.Application.DTOs.Item;
using POS.Application.Features.Item.Queries;

namespace POS.Application.Features.Item.Handlers
{
    public class GetItemsQueryHandler : IRequestHandler<GetItemsQuery, IEnumerable<ItemResponseDTO>>
    {
        private readonly IItemRepository _itemRepository;
        private readonly IMapper _mapper;

        public GetItemsQueryHandler(IItemRepository itemRepository, IMapper mapper)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ItemResponseDTO>> Handle(GetItemsQuery request, CancellationToken cancellationToken)
        {
            var items = await _itemRepository.GetAllItemsAsync();

            // Map list of entities to list of DTOs
            return _mapper.Map<IEnumerable<ItemResponseDTO>>(items);
        }
    }
}
