using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using ProjectMgmtSystem.Models.TaskModel;

namespace ProjectMgmtSystem.Controllers
{
    [ApiController]
    public class TaskController : Controller
    {
        private readonly ITaskRepository _repository;

        public TaskController(ITaskRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult Get()
        {
            var result = _repository.GetAllTasks();
            return Ok(result);
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult Get(int id)
        {
            var result = _repository.GetTaskById(id);
            if(result == null)
            {
                return NotFound("no task found");
            }
            return Ok(result);
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult Post(Task task)
        {
            var result = _repository.CreateTask(task);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + "/" + HttpContext.Request.Path + "/" + task.Id, result);
        }

        [HttpPost]
        [Route("api/[controller]/{id}")]
        public IActionResult Post(int id, Task task)
        {
            var result = _repository.UpdateTask(id, task);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + "/" + HttpContext.Request.Path + "/" + task.Id, result);
        }

        [HttpDelete]
        [Route("api/[controller]")]
        public string Delete(int id)
        {
            return _repository.DeleteTask(id);
        }
    }
}
