using System.Net;
using AutoMapper;
using MediatR;
using POS.Application.DTOs.Order;
using POS.Application.DTOs.OrderItem;
using POS.Application.Exceptions;
using POS.Application.Features.Order.Command;
using POS.Application.Interfaces.Repositories;
using POS.Application.Interfaces.Services;
using POS.Domain.Entities;
using POS.Domain.Enums;

namespace POS.Application.Features.Order.Handlers
{
    public class CreateOrderByCustomerCommandHandler : IRequestHandler<CreateOrderByCustomerCommand, OrderDetailsDTO>
    {

        private readonly IUserRepository _userRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderCreationService _orderCreationService;
        private readonly IMapper _mapper;
        

        public CreateOrderByCustomerCommandHandler(IUserRepository userRepository, IOrderRepository orderRepository, IOrderCreationService orderCreationService,
            IMapper mapper
            ){
            _orderRepository = orderRepository;
            _userRepository = userRepository;
            _orderCreationService = orderCreationService;
            _mapper = mapper; 
        }

        
        public async Task<OrderDetailsDTO> Handle(CreateOrderByCustomerCommand request, 
            CancellationToken cancellationToken)
        {
            OrderEntity newOrder = await _orderCreationService.CreateOrderAsync(request.userId, [.. request.orderItems]);

            OrderDetailsDTO result = _mapper.Map<OrderDetailsDTO>(newOrder);

            return result;

        }
    }
}
