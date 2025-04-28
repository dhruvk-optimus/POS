using Microsoft.EntityFrameworkCore;
using POS.Application.Interfaces.Repositories;
using POS.Domain.Entities;
using POS.Domain.Enums;
using POS.Persistence.Data;

namespace POS.Infrastructure.Repositories
{
    public class UserRepository(POSDbContext _context) : IUserRepository
    {
        public async Task<IEnumerable<UserEntity>> GetAllAsync(UserRole? role)
        {
            var query = _context.Users.AsQueryable();

            if (!string.IsNullOrEmpty(role.ToString()))
            {
                query = query.Where(u => u.Role == role);
            }

            return await query.ToListAsync();
        }
        public async Task<UserEntity?> GetByEmailAsync(string email)
        {
            UserEntity? user = await _context.Users
    .FirstOrDefaultAsync(u => EF.Functions.Like(u.Email, email));

            return user;
        }

        public async Task<UserEntity?> GetByIdAsync(Guid id)
        {
            UserEntity? user = await _context.Users.FindAsync(id);
            return user;
        }

        public async Task<UserEntity> AddAsync(UserEntity user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task DeleteAsync(Guid id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

    }
}
