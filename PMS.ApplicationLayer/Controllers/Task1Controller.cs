using Microsoft.AspNetCore.Mvc;
using PMS.ApplicationDomainLayer.TaskModel;
using PMS.PersistenceLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMS.ApplicationLayer.Controllers
{
    [ApiController]
    public class Task1Controller : Controller
    {
        private readonly IGenericRepository<Task1> _tasks;

        public Task1Controller(IGenericRepository<Task1> tasks)
        {
            _tasks = tasks;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public async Task<ActionResult<Task1>> Get()
        {
            return Ok(await _tasks.GetAllAsync());
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public async Task<ActionResult<Task1>> Get(int id)
        {
            var result = await _tasks.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound($"No task with id : {id}");
            }
            return Ok(result);
        }

        [HttpPost]
        [Route("api/[controller]")]
        public async Task<ActionResult<Task1>> Post(Task1 task)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _tasks.CreateAsync(task));
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut]
        [Route("api/[controller]/{id}")]
        public async Task<ActionResult<Task1>> Put(int id, Task1 inpTask)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _tasks.UpdateAsync(id, inpTask));
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public async Task<ActionResult<Task1>> Delete(int id)
        {
            var result = await _tasks.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound($"No task with id : {id}");
            }
            result = await _tasks.DeleteAsync(id);
            return Ok(result);
        }
    }
}
