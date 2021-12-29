using Microsoft.AspNetCore.Mvc;
using PMS.ApplicationDomainLayer.UserModel;
using PMS.PersistenceLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMS.ApplicationLayer.Controllers
{
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
        public async Task<ActionResult<User>> Get()
        {
            return Ok(await _users.GetAllAsync());
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public async Task<ActionResult<User>> Get(int id)
        {
            var result = await _users.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound($"No user with id : {id}");
            }
            return Ok(result);
        }

        [HttpPost]
        [Route("api/[controller]")]
        public async Task<ActionResult<User>> Post(User user)
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

        [HttpPut]
        [Route("api/[controller]/{id}")]
        public async Task<ActionResult<User>> Put(int id, User inpUser)
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
        [Route("api/[controller]/{id}")]
        public async Task<ActionResult<User>> Delete(int id)
        {
            var result = await _users.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound($"No user with id : {id}");
            }
            result = await _users.DeleteAsync(id);
            return Ok(result);
        }
    }
}
