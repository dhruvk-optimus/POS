using System.Net;
using AutoMapper;
using MediatR;
using POS.Application.DTOs.Order;
using POS.Application.DTOs.OrderItem;
using POS.Application.Exceptions;
using POS.Application.Features.Order.Queries;
using POS.Application.Interfaces.Repositories;
using POS.Domain.Entities;
using POS.Domain.Enums;

namespace POS.Application.Features.Order.Handlers
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, OrderDetailsDTO>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public GetOrderByIdQueryHandler(IOrderRepository orderRepository , IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }


        public async Task<OrderDetailsDTO> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            // 1. Get the order by OrderId
            OrderEntity? order = await _orderRepository.GetAsync(request.OrderId);

            if(order == null)
            {
                throw new ApiException("Invalid OrderId", HttpStatusCode.BadRequest);
            }

            // 2. Check if the Role of the current user is customer and the Order belongs to that customer 
            if(request.Role == UserRole.Customer && order.UserId != request.UserId)
            {
                throw new ApiException("Not allowed", HttpStatusCode.Forbidden);
            }

            OrderDetailsDTO result = _mapper.Map<OrderDetailsDTO>(order);

            return result;
            

        }
    }
}
