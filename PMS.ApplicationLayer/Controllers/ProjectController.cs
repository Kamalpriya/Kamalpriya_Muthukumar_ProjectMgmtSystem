using Microsoft.AspNetCore.Mvc;
using PMS.ApplicationDomainLayer.ProjectModel;
using PMS.PersistenceLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMS.ApplicationLayer.Controllers
{
    // (Sprint II) -- 4. Call Repository methods from api end point : for Project 
    [ApiController]
    public class ProjectController : Controller
    {
        private readonly IGenericRepository<Project> _projects;

        public ProjectController(IGenericRepository<Project> projects)
        {
            _projects = projects;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public async Task<IActionResult> Get()
        {
            // (Sprint II) -- 4. Call Repository methods from api end point : for Project 
            return Ok(await _projects.GetAllAsync());
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _projects.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        [Route("api/[controller]")]
        public async Task<IActionResult> Post(Project project)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _projects.CreateAsync(project));
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPost]
        [Route("api/[controller]/{id}")]
        public async Task<IActionResult> Post(int id, Project inpProject)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _projects.UpdateAsync(id, inpProject));
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
            var result = await _projects.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            result = await _projects.DeleteAsync(id);
            return Ok(result);
        }
    }
}
