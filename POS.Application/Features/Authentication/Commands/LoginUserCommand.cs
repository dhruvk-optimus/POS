using MediatR;
using POS.Application.DTOs.Authentication;

namespace POS.Application.Features.Authentication.Commands
{
    public record LoginUserCommand (LoginUserRequestDTO User) : IRequest<AuthResponseDTO>;
}
