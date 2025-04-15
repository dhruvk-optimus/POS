using MediatR;

namespace POS.Application.Features.User.Commands
{
    public record DeleteUserCommand(Guid UserId) : IRequest;
}
