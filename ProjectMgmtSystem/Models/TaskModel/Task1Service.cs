using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMgmtSystem.Models.TaskModel
{
    // 2b. Task service with CRUD api implementations (Sprint I)

    // 1. Implementation of task repository interface (Sprint II)
    public class Task1Service : ITask1Repository
    {
        private readonly AppDBContext _context;

        public Task1Service(AppDBContext context)
        {
           _context = context;
        }

        async Task<Task1> ITask1Repository.CreateTaskAsync(Task1 inptask)
        {
            _context.Tasks.Add(inptask);
            await _context.SaveChangesAsync();
            return inptask;
        }

        async Task<Task1> ITask1Repository.DeleteTaskAsync(int id)
        {
            var result = _context.Tasks.FirstOrDefault(task => task.Id == id);
            _context.Tasks.Remove(result);
            await _context.SaveChangesAsync();
            return result;
        }

        async Task<List<Task1>> ITask1Repository.GetAllTasksAsync()
        {
            return await _context.Tasks.ToListAsync();
        }

        async Task<Task1> ITask1Repository.GetTaskByIdAsync(int id)
        {
            return await _context.Tasks.FirstOrDefaultAsync(Task => Task.Id == id);
        }

        async Task<Task1> ITask1Repository.UpdateTaskAsync(int id, Task1 inpTask)
        {
            var result = _context.Tasks.FirstOrDefault(Task => Task.Id == id);
            _context.Tasks.Remove(result);
            _context.Tasks.Add(inpTask);
            await _context.SaveChangesAsync();
            return inpTask;
        }
    }
}
