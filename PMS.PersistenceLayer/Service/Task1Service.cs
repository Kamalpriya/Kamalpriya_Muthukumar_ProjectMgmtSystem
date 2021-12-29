using Microsoft.EntityFrameworkCore;
using PMS.ApplicationDomainLayer.TaskModel;
using PMS.DataAccessLayer;
using PMS.PersistenceLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.PersistenceLayer.Service
{
    public class Task1Service : IGenericRepository<Task1>
    {
        private readonly AppDBContext _context;

        public Task1Service(AppDBContext context)
        {
            _context = context;
        }

        public async Task<Task1> CreateAsync(Task1 inptask)
        {
            _context.Tasks.Add(inptask);
            await _context.SaveChangesAsync();
            return inptask;
        }

        public async Task<Task1> DeleteAsync(int id)
        {
            var result = _context.Tasks.FirstOrDefault(task => task.Id == id);
            _context.Tasks.Remove(result);
            await _context.SaveChangesAsync();
            return result;
        }

        public async Task<List<Task1>> GetAllAsync()
        {
            return await _context.Tasks.ToListAsync();
        }

        public async Task<Task1> GetByIdAsync(int id)
        {
            return await _context.Tasks.FirstOrDefaultAsync(Task => Task.Id == id);
        }

        public async Task<Task1> UpdateAsync(int id, Task1 inpTask)
        {
            var result = _context.Tasks.FirstOrDefault(Task => Task.Id == id);
            _context.Tasks.Remove(result);
            _context.Tasks.Add(inpTask);
            await _context.SaveChangesAsync();
            return inpTask;
        }
    }
}
