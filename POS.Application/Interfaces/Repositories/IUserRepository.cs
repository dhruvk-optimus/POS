using POS.Domain.Entities;
using POS.Domain.Enums;

namespace POS.Application.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<UserEntity?> GetByEmailAsync(string email);
         Task<UserEntity> AddAsync(UserEntity user);

        Task<IEnumerable<UserEntity>> GetAllAsync(UserRole? role);
        Task DeleteAsync(Guid id);

        Task<UserEntity?> GetByIdAsync(Guid id);
    }
}
