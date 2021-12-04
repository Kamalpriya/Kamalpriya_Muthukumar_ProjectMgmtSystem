using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectMgmtSystem.Models.ProjectModel;

namespace ProjectMgmtSystem.Controllers
{
    [ApiController]
    public class ProjectController : Controller
    {
        private readonly IProjectRepository _repository;

        public ProjectController(IProjectRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult Get()
        {
            var result = _repository.GetAllProjects();
            return Ok(result);
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult Get(int id)
        {
            var result = _repository.GetProjectById(id);
            if(result == null)
            {
                return NotFound("no Project found");
            }
            return Ok(result);
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult Post(Project Project)
        {
            var result = _repository.CreateProject(Project);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + "/" + HttpContext.Request.Path + "/" + Project.Id, result);
        }

        [HttpPost]
        [Route("api/[controller]/{id}")]
        public IActionResult Post(int id, Project Project)
        {
            var result = _repository.UpdateProject(id, Project);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + "/" + HttpContext.Request.Path + "/" + Project.Id, result);
        }

        [HttpDelete]
        [Route("api/[controller]")]
        public string Delete(int id)
        {
            return _repository.DeleteProject(id);
        }
    }
}
