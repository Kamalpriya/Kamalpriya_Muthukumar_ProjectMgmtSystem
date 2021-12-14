using Microsoft.EntityFrameworkCore;
using ProjectMgmtSystem.Models.UserModel;
using ProjectMgmtSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMgmtSystem.Service
{
    // (Sprint II) -- 1. Implementation of generic repository for User
    public class UserService : IGenericRepository<User>
    {
        private readonly AppDBContext _context;

        public UserService(AppDBContext context)
        {
            _context = context;
        }

        public async Task<User> CreateAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> DeleteAsync(int id)
        {
            var result = _context.Users.FirstOrDefault(user => user.Id == id);
            _context.Users.Remove(result);
            await _context.SaveChangesAsync();
            return result;
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(user => user.Id == id);
        }

        public async Task<User> UpdateAsync(int id, User inpUser)
        {
            var result = _context.Users.FirstOrDefault(user => user.Id == id);
            _context.Users.Remove(result);
            _context.Users.Add(inpUser);
            await _context.SaveChangesAsync();
            return inpUser;
        }
    }
}
