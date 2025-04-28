using System.Net;
using AutoMapper;
using MediatR;
using POS.Application.DTOs.Order;
using POS.Application.Exceptions;
using POS.Application.Features.Order.Command;
using POS.Application.Interfaces.Repositories;
using POS.Application.Interfaces.Services;
using POS.Domain.Entities;

namespace POS.Application.Features.Order.Handlers
{
    public class CreateOrderByCashierCommandHandler : IRequestHandler<CreateOrderByCashierCommand, OrderDetailsDTO>
    {

        private readonly IUserRepository _userRepository;
        private readonly IOrderCreationService _orderCreationService;
        private readonly IMapper _mapper;
            

        public CreateOrderByCashierCommandHandler(
            IUserRepository userRepository, IOrderCreationService orderCreationService, IMapper mapper
            )
        {
            _userRepository = userRepository;
            _orderCreationService = orderCreationService;
            _mapper = mapper;
        }

        public async Task<OrderDetailsDTO> Handle(CreateOrderByCashierCommand request, CancellationToken cancellationToken)
        {
            UserEntity? user = await _userRepository.GetByEmailAsync(request.email);


            if (user == null)
            {
                throw new ApiException("No user with that email exists.", HttpStatusCode.BadRequest);
            }

            OrderEntity newOrder = await _orderCreationService.CreateOrderAsync(user.UserId, [.. request.orderItems]);

            OrderDetailsDTO result = _mapper.Map<OrderDetailsDTO>(newOrder);

            return result;


        }

    }
}
