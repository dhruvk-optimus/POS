using MediatR;
using POS.Application.DTOs.User;
using POS.Domain.Enums;

namespace POS.Application.Features.User.Queries
{
    public record GetUsersQuery(UserRole? Role) : IRequest<IEnumerable<UserResponseDTO>>;
}
