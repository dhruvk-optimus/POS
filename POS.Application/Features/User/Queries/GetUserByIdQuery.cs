using MediatR;
using POS.Application.DTOs.User;

namespace POS.Application.Features.User.Queries
{
    public record GetUserByIdQuery(Guid UserId) : IRequest<UserResponseDTO>;

}
