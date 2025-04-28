using System.Data;
using POS.Application.DTOs.Order;
using POS.Application.DTOs.OrderItem;
using POS.Application.Exceptions;
using POS.Application.Interfaces.Repositories;
using POS.Application.Interfaces.Services;
using POS.Domain.Entities;
using POS.Domain.Enums;

namespace POS.Application.Features.Order.Services
{
    public class OrderCreationService : IOrderCreationService
    {

        public readonly IUnitOfWork _unitOfWork;
        public readonly IOrderRepository _orderRepository;
        public readonly IUserRepository _userRepository;
        public readonly IItemRepository _itemRepository;


        public OrderCreationService(
            IUnitOfWork unitOfWork,
            IOrderRepository orderRepository,
            IUserRepository userRepository,
            IItemRepository itemRepository
        )
        {
            _unitOfWork = unitOfWork;
            _orderRepository = orderRepository;
            _userRepository = userRepository;
            _itemRepository = itemRepository;
        }

        public async Task<OrderEntity> CreateOrderAsync(Guid userId, List<CreateOrderItemRequestDTO> orderItems)
        {
            try
            {

                // 1. Begin transaction
                await _unitOfWork.BeginTransactionAsync(IsolationLevel.Serializable);


                // 2. Check is user exists
                UserEntity? existingUser = await _userRepository.GetByIdAsync(userId);

                if (existingUser is null)
                {
                    throw new ApiException("User doesn't exist", System.Net.HttpStatusCode.NotFound);
                }

                decimal totalAmount = 0m;

                // 2. Create OrderItems List
                List<OrderItemEntity> orderItemsList = new List<OrderItemEntity>();
                foreach (CreateOrderItemRequestDTO orderItem in orderItems)
                {

                    // NOTE: Convert this into Batch request
                    ItemEntity? existingItem = await _itemRepository.GetItemByIdAsync(orderItem.ItemId);

                    if (existingItem is null)
                    {
                        throw new ApiException($"Item with ID {orderItem.ItemId} not found.", System.Net.HttpStatusCode.NotFound);
                    }

                    if (existingItem.AvailableStock < orderItem.Quantity)
                    {
                        throw new ApiException($"Not enough stock for item with ID {orderItem.ItemId}.", System.Net.HttpStatusCode.BadRequest);
                    }


                    totalAmount += orderItem.Quantity * existingItem.Price;

                    orderItemsList.Add(new OrderItemEntity
                    {
                        ItemId = orderItem.ItemId,
                        Quantity = orderItem.Quantity,
                        UnitPrice = existingItem.Price,

                    });

                    existingItem.AvailableStock -= orderItem.Quantity;


                }

                OrderEntity order = new OrderEntity
                {
                    UserId = userId,
                    OrderItems = orderItemsList,
                    Status = OrderStatus.Confirmed,
                    TotalAmount = totalAmount
                };

                await _orderRepository.AddAsync(order);



                await _unitOfWork.SaveChangesAsync();

                await _unitOfWork.CommitTransactionAsync();




                return order;

            }

            catch (ApiException ex)
            {
                await _unitOfWork.RollbackTransactionAsync();
                throw new ApiException(ex.Message, ex.StatusCode);
            }

        }
    }
}
