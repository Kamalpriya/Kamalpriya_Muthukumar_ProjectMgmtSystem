using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMgmtSystem.Models.UserModel
{
    // 1. Repository interface for User (Sprint II)
    public interface IUserRepository
    {
        public Task<User> CreateUserAsync (User user);
        public Task<User> UpdateUserAsync(int id, User user);
        public Task<List<User>> GetAllUsersAsync();
        public Task<User> GetUserByIdAsync(int id);
        public Task<User> DeleteUserAsync(int id);
    }
}
