using MediatR;
using POS.Application.DTOs.Authentication;
using POS.Domain.Entities;


namespace POS.Application.Features.Authentication.Commands
{
    public record RegisterUserCommand(RegisterUserRequestDTO User) : IRequest<AuthResponseDTO>;
}
