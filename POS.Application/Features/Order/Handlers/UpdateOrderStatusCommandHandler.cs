using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using POS.Application.DTOs.Order;
using POS.Application.Exceptions;
using POS.Application.Features.Order.Command;
using POS.Application.Interfaces.Repositories;
using POS.Domain.Entities;
using POS.Domain.Enums;

namespace POS.Application.Features.Order.Handlers
{
    public class UpdateOrderStatusCommandHandler : IRequestHandler<UpdateOrderStatusCommand, OrderSummaryDTO>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper; 

        public UpdateOrderStatusCommandHandler(
            IOrderRepository orderRepository,
            IMapper mapper
            )
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }


        private bool IsValidStatusTransition(OrderStatus currentStatus, OrderStatus newStatus)
        {
            return (currentStatus, newStatus) switch
            {
                (OrderStatus.Pending, OrderStatus.Confirmed) => true,
                (OrderStatus.Pending, OrderStatus.Cancelled) => true,
                (OrderStatus.Confirmed, OrderStatus.Shipped) => true,
                (OrderStatus.Confirmed, OrderStatus.Cancelled) => true,
                (OrderStatus.Shipped, OrderStatus.Delivered) => true,

                _ => false, // any other transition is invalid
            };
        }


        public async Task<OrderSummaryDTO> Handle(UpdateOrderStatusCommand request, CancellationToken cancellationToken)
        {
            OrderEntity? order = await _orderRepository.GetAsync(request.orderId);

            if (order == null)
            {
                throw new ApiException("Order does not exist", HttpStatusCode.BadRequest);
            }

            if(!IsValidStatusTransition(order.Status, request.orderStatus))
            {
                throw new ApiException($"Invalid status transition from {order.Status} to {request.orderStatus}", HttpStatusCode.BadRequest);
            }

            order.Status = request.orderStatus;

            await _orderRepository.UpdateAsync(order);

            var orderSummary = _mapper.Map<OrderSummaryDTO>(order);

            return orderSummary;


        } 
    }
}
