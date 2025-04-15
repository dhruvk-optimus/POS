using MediatR;
using Microsoft.AspNetCore.Mvc;
using POS.Application.DTOs.Authentication;
using POS.Application.Features.Authentication.Commands;


namespace POS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IMediator mediator) : ControllerBase
    {

        [HttpPost("register")]
        public async Task<ActionResult<AuthResponseDTO>> Register([FromBody] RegisterUserRequestDTO request)
        {
            // FIX this var
            AuthResponseDTO result = await mediator.Send(new RegisterUserCommand(request));
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthResponseDTO>> Login([FromBody] LoginUserRequestDTO request)
        {

            AuthResponseDTO result = await mediator.Send(new LoginUserCommand(request));
            return Ok(result);
        }
    }
}
