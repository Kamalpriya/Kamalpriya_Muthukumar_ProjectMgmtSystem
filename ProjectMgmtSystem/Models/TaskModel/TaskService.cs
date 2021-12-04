using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMgmtSystem.Models.TaskModel
{
    public class TaskService : ITaskRepository
    {
        private List<Task> Tasks;
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
            Task Task = GetTaskById(id);
            Tasks.Remove(Task);
            Tasks.Insert(id - 1, inpTask); // list indexing starts from 0, insert at i-1
            return GetTaskById(id);
        }
    }
}
