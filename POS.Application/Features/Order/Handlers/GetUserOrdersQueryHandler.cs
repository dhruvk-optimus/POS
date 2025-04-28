using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using POS.Application.DTOs.Order;
using POS.Application.Features.Order.Queries;
using POS.Application.Interfaces.Repositories;
using POS.Domain.Entities;

namespace POS.Application.Features.Order.Handlers
{
    public class GetUserOrdersQueryHandler : IRequestHandler<GetUserOrdersQuery, IEnumerable<OrderSummaryDTO>>
    {

        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public GetUserOrdersQueryHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrderSummaryDTO>> Handle(GetUserOrdersQuery request, CancellationToken cancellationToken)
        {
            Guid UserId = request.UserId;

            IEnumerable<OrderEntity> orders = await _orderRepository.GetAllByUserAsync(UserId); 
            
            IEnumerable<OrderSummaryDTO> result= _mapper.Map<IEnumerable<OrderSummaryDTO>> (orders);

            return result;


        }
    }
}
