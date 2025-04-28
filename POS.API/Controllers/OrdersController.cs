using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using POS.Application.DTOs.Order;
using POS.Application.DTOs.OrderItem;
using POS.Application.Features.Order.Command;
using POS.Application.Features.Order.Queries;
using POS.Domain.Enums;

namespace POS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;


        private bool TryGetUserId(out Guid userId)
        {
            userId = Guid.Empty;
            string? userIdString = User.FindFirst("UserId")?.Value;

            if (string.IsNullOrEmpty(userIdString))
            {
                return false;
            }

            return Guid.TryParse(userIdString, out userId);
        }

        private bool TryGetUserRole(out UserRole userRole)
        {
            userRole = default;
            string? roleString = User.FindFirst(ClaimTypes.Role)?.Value;

            if (string.IsNullOrEmpty(roleString))
            {
                return false;
            }

            return Enum.TryParse(roleString, out userRole);
        }




        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Cashier")]
        public async Task<ActionResult<IEnumerable<OrderDTO>>> GetAllOrders()
        {
            IEnumerable<OrderDTO> result = await _mediator.Send(new GetAllOrdersQuery());

            return Ok(result);
        }

        [HttpGet]
        [Route("my")]
        [Authorize(Roles = "Customer")]
        public async Task <ActionResult<IEnumerable<OrderSummaryDTO>>> GetMyOrders()
        {
            if (!TryGetUserId(out Guid userId))
            {
                return BadRequest("User ID not found in token.");
            }
            IEnumerable<OrderSummaryDTO> result = await _mediator.Send(new GetUserOrdersQuery(userId));
            return Ok(result);
        }


        [HttpGet("{OrderId}")]
        [Authorize]
        public async Task<ActionResult<OrderDetailsDTO>> GetOrderById([FromRoute] Guid OrderId)
        {
            if (!TryGetUserId(out Guid userId))
            {
                return BadRequest("Invalid UserId");
            }

            if (!TryGetUserRole(out UserRole userRole))
            {
                return BadRequest("Invalid User");
            }

            OrderDetailsDTO result = await _mediator.Send(new GetOrderByIdQuery(OrderId, userId, userRole));

            return Ok(result);
        }


        [HttpPost("/customer")]
        [Authorize(Roles = "Customer")]
        public async Task<ActionResult<OrderDetailsDTO>> CreateOrderByCustomer([FromBody] IEnumerable<CreateOrderItemRequestDTO> orderItems)
        {
            if (!TryGetUserId(out Guid userId))
            {
                return BadRequest("Invalid UserId");
            }

            OrderDetailsDTO result = await _mediator.Send(new CreateOrderByCustomerCommand(userId, orderItems));

            return Ok(result);
        }


        [HttpPost("/cashier")]
        [Authorize(Roles = "Cashier")]
        public async Task<ActionResult<OrderDetailsDTO>> CreateOrderByCashier([FromBody] CreateOrderByCashierRequestDTO request)
        {

            OrderDetailsDTO result = await _mediator.Send(new CreateOrderByCashierCommand(request.email, request.orderItems));

            return Ok(result);
        }

        [HttpPatch("/status/{orderId}")]
        [Authorize(Roles = "Admin,Cashier")]
        public async Task<ActionResult<OrderSummaryDTO>> UpdateOrderStatus([FromRoute] Guid orderId, [FromBody] OrderStatus status)
        { 
            OrderSummaryDTO result = await _mediator.Send(new UpdateOrderStatusCommand(orderId, status));

            return Ok(result);

        }
    }
}
