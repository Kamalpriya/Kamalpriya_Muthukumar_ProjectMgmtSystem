using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectMgmtSystem.Models.UserModel;
using ProjectMgmtSystem.Repository;

namespace ProjectMgmtSystem.Controllers
{
    // 2a. User Controller with CRUD api's and action methods (Sprint I)
    [ApiController]
    public class UserController : Controller
    {
        private readonly IGenericRepository<User> _users;

        public UserController(IGenericRepository<User> users)
        {
            _users = users;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _users.GetAllAsync());
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _users.GetByIdAsync(id);
            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        [Route("api/[controller]")]
        public async Task<IActionResult> Post(User user)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _users.CreateAsync(user));
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPost]
        [Route("api/[controller]/{id}")]
        public async Task<IActionResult> Post(int id, User inpUser)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _users.UpdateAsync(id, inpUser));
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
            var result = await _users.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            result = await _users.DeleteAsync(id);
            return Ok(result);
        }
    }
}
