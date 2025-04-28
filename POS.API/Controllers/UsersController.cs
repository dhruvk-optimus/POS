using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using POS.Application.DTOs.User;
using POS.Application.Features.User.Commands;
using POS.Application.Features.User.Queries;
using POS.Domain.Enums;

namespace POS.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator) => _mediator = mediator;

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<UserResponseDTO>>> GetUsers([FromQuery] UserRole? role = null)
        {
            var query = new GetUsersQuery(role);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{userId}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<UserResponseDTO>> GetUserById(Guid userId)
        {
            var query = new GetUserByIdQuery(userId);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost("admin")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<UserResponseDTO>> CreateAdmin([FromBody] CreateUserRequestDTO request)
        {
            var command = new CreateAdminCommand(request);
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetUserById), new { userId = result.UserId }, result);
        }

        [HttpPost("cashier")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<UserResponseDTO>> CreateCashier([FromBody] CreateUserRequestDTO request)
        {
            var command = new CreateCashierCommand(request);
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetUserById), new { userId = result.UserId }, result);
        }


        [HttpDelete("{userId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteUser(Guid userId)
        {
            var command = new DeleteUserCommand(userId);
            await _mediator.Send(command);
            return NoContent();
        }
    }

}