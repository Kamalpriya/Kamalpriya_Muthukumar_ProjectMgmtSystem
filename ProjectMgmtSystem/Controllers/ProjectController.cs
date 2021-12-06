using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectMgmtSystem.Models.ProjectModel;

namespace ProjectMgmtSystem.Controllers
{
    // 2a. Project Controller with CRUD api's and action methods (Sprint I)
    [ApiController]
    public class ProjectController : Controller
    {
        private readonly IProjectRepository _projects;

        public ProjectController(IProjectRepository projects)
        {
            _projects = projects;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _projects.GetAllProjectsAsync());
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _projects.GetProjectByIdAsync(id);
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
                return Ok(await _projects.CreateProjectAsync(project));
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
                return Ok(await _projects.UpdateProjectAsync(id, inpProject));
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
            var result = await _projects.GetProjectByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            result = await _projects.DeleteProjectAsync(id);
            return Ok(result);
        }
    }
}
