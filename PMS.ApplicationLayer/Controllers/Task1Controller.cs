using Microsoft.AspNetCore.Mvc;
using PMS.ApplicationDomainLayer.TaskModel;
using PMS.PersistenceLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMS.ApplicationLayer.Controllers
{
    // (Sprint II) -- 4. Call Repository methods from api end point : for Task 
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
        public async Task<IActionResult> Get()
        {
            // (Sprint II) -- 4. Call Repository methods from api end point : for Task
            return Ok(await _tasks.GetAllAsync());
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _tasks.GetByIdAsync(id);
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
                return Ok(await _tasks.CreateAsync(task));
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
                return Ok(await _tasks.UpdateAsync(id, inpTask));
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
            var result = await _tasks.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            result = await _tasks.DeleteAsync(id);
            return Ok(result);
        }
    }
}
