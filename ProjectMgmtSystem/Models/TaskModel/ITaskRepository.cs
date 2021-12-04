using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMgmtSystem.Models.TaskModel
{
    public interface ITaskRepository
    {
        public Task CreateTask(Task Task);
        public Task UpdateTask(int id, Task Task);
        public List<Task> GetAllTasks();
        public Task GetTaskById(int id);
        public string DeleteTask(int id);
    }
}
