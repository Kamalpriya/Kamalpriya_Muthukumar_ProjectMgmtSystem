using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMgmtSystem.Models.TaskModel
{
    // 1. Repository interface for Task (Sprint II)
    public interface ITask1Repository
    {
        public Task<Task1> CreateTaskAsync(Task1 task);
        public Task<Task1> UpdateTaskAsync(int id, Task1 Task);
        public Task<List<Task1>> GetAllTasksAsync();
        public Task<Task1> GetTaskByIdAsync(int id);
        public Task<Task1> DeleteTaskAsync(int id);
    }
}
