using MediatR;
using POS.Application.DTOs.User;

namespace POS.Application.Features.User.Commands
{
    public record CreateAdminCommand(CreateUserRequestDTO User) : IRequest<UserResponseDTO>;
}
