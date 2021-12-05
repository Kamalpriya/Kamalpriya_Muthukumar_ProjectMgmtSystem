using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMgmtSystem.Models.TaskModel
{
    // 2b. Task service with CRUD api implementations
    public class TaskService : ITaskRepository
    {
        private static List<Task> Tasks;
        private static int cnt = 4;

        public TaskService()
        {
            Tasks = new List<Task>()
            {
                new Task(){Id=1, ProjectId=1, Status=2, AssignedToUserId=1, Detail="This is a test task", CreatedOn=DateTime.Now},
                new Task(){Id=2, ProjectId=1, Status=3, AssignedToUserId=2, Detail="This is a test task", CreatedOn=DateTime.Now},
                new Task(){Id=3, ProjectId=2, Status=4, AssignedToUserId=2, Detail="This is a test task", CreatedOn=DateTime.Now}
            };
        }
        public Task CreateTask(Task task)
        {
            task.Id = ++cnt;
            Tasks.Add(task);
            return task;
        }

        public string DeleteTask(int id)
        {
            Task Task = GetTaskById(id);
            Tasks.Remove(Task);
            cnt--;
            return "Task deleted";
        }

        public List<Task> GetAllTasks()
        {
            return Tasks;
        }

        public Task GetTaskById(int id)
        {
            foreach (var Task in Tasks)
            {
                if(Task.Id == id)
                {
                    return Task;
                }
            }
            return null;
        }

        public Task UpdateTask(int id, Task inpTask)
        {
            Task task = GetTaskById(id);
            Tasks.Remove(task);
            Tasks.Add(inpTask);
            return GetTaskById(inpTask.Id);
        }
    }
}
