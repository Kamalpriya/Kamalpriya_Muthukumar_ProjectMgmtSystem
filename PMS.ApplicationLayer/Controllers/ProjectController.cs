using Microsoft.AspNetCore.Mvc;
using PMS.ApplicationDomainLayer.ProjectModel;
using PMS.PersistenceLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMS.ApplicationLayer.Controllers
{
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
        public async Task<ActionResult<Project>> Get()
        {
            return Ok(await _projects.GetAllAsync());
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public async Task<ActionResult<Project>> Get(int id)
        {
            var result = await _projects.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound($"No project with id : {id}");
            }
            return Ok(result);
        }

        [HttpPost]
        [Route("api/[controller]")]
        public async Task<ActionResult<Project>> Post(Project project)
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

        [HttpPut]
        [Route("api/[controller]/{id}")]
        public async Task<ActionResult<Project>> Put(int id, Project inpProject)
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
        [Route("api/[controller]/{id}")]
        public async Task<ActionResult<Project>> Delete(int id)
        {
            var result = await _projects.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound($"No project with id : {id}");
            }
            result = await _projects.DeleteAsync(id);
            return Ok(result);
        }
    }
}
