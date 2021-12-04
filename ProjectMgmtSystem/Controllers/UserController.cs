﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectMgmtSystem.Models.UserModel;

namespace ProjectMgmtSystem.Controllers
{
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserRepository _repository;

        public UserController(IUserRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult Get()
        {
            var result = _repository.GetAllUsers();
            return Ok(result);
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult Get(int id)
        {
            var result = _repository.GetUserById(id);
            if(result == null)
            {
                return NotFound("no user found");
            }
            return Ok(result);
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult Post(User user)
        {
            var result = _repository.CreateUser(user);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + "/" + HttpContext.Request.Path + "/" + user.Id, result);
        }

        [HttpPost]
        [Route("api/[controller]/{id}")]
        public IActionResult Post(int id, User user)
        {
            var result = _repository.UpdateUser(id, user);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + "/" + HttpContext.Request.Path + "/" + user.Id, result);
        }

        [HttpDelete]
        [Route("api/[controller]")]
        public string Delete(int id)
        {
            return _repository.DeleteUser(id);
        }
    }
}