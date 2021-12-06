using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMgmtSystem.Models.UserModel
{
    // 2b. User service with CRUD api implementations (Sprint I)
    
    // 1. Implementation of user repository interface (Sprint II)
    public class UserService : IUserRepository
    {
        private readonly AppDBContext _context;

        public UserService(AppDBContext context)
        {
             _context = context;
        }

        async Task<User> IUserRepository.CreateUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        async Task<User> IUserRepository.DeleteUserAsync(int id)
        {
            var result = _context.Users.FirstOrDefault(user => user.Id == id);
            _context.Users.Remove(result);
            await _context.SaveChangesAsync();
            return result;
        }

        async Task<List<User>> IUserRepository.GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        async Task<User> IUserRepository.GetUserByIdAsync(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(user => user.Id == id);
        }

        async Task<User> IUserRepository.UpdateUserAsync(int id, User inpUser)
        {
            var result = _context.Users.FirstOrDefault(user => user.Id == id);
            _context.Users.Remove(result);
            _context.Users.Add(inpUser);
            await _context.SaveChangesAsync();
            return inpUser;
        }
    }
}
