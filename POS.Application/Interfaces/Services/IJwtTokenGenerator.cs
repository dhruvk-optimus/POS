using POS.Domain.Entities;

namespace POS.Application.Interfaces.Services
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(UserEntity user);
    }
}
