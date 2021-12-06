using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectMgmtSystem.Models.TaskModel;

namespace ProjectMgmtSystem.Controllers
{
    // 2a. Task Controller with CRUD api's and action methods (Sprint I)
    [ApiController]
    public class Task1Controller : Controller
    {
        private readonly ITask1Repository _tasks;

        public Task1Controller(ITask1Repository tasks)
        {
            _tasks = tasks;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _tasks.GetAllTasksAsync());
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _tasks.GetTaskByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        [Route("api/[controller]")]
        public async Task<IActionResult> Post(Task1 task)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _tasks.CreateTaskAsync(task));
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPost]
        [Route("api/[controller]/{id}")]
        public async Task<IActionResult> Post(int id, Task1 inpTask)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _tasks.UpdateTaskAsync(id, inpTask));
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete]
        [Route("api/[controller]")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _tasks.GetTaskByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            result = await _tasks.DeleteTaskAsync(id);
            return Ok(result);
        }
    }
}
