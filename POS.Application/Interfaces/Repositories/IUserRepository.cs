using POS.Domain.Entities;
using POS.Domain.Enums;

namespace POS.Application.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserEntity>> GetAllAsync(UserRole? role);
        Task<UserEntity?> GetByEmailAsync(string email);
        Task<UserEntity?> GetByIdAsync(Guid id);
        Task<UserEntity> AddAsync(UserEntity user);
        Task DeleteAsync(Guid id);

    }
}
