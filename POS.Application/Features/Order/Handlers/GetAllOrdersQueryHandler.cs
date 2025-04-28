using AutoMapper;
using MediatR;
using POS.Application.DTOs.Order;
using POS.Application.Features.Order.Queries;
using POS.Application.Interfaces.Repositories;

namespace POS.Application.Features.Order.Handlers
{
    public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, IEnumerable<OrderDTO>>
    {

        public readonly IOrderRepository _orderRepository;
        public readonly IMapper _mapper;    

        public GetAllOrdersQueryHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrderDTO>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            var orders = await _orderRepository.GetAllAsync();

            IEnumerable<OrderDTO> result = _mapper.Map<IEnumerable<OrderDTO>>(orders);
            return result;
        }
    }
}
