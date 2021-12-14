using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectMgmtSystem.Models;

namespace ProjectMgmtSystem.Controllers
{
    // 4. User Login Controller with CRUD api and action method (Sprint I)
    public class UserLoginController : Controller
    {
        private readonly AppDBContext _context;

        public UserLoginController(AppDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            UserLogin obj = new UserLogin();
            return View(obj);
        }

        [HttpPost]
        [Route("api/[controller]")]
        public string Index(UserLogin userlogin)
        {
            if (ModelState.IsValid)
            {
                var result = _context.Logins.Where(m => m.Username == userlogin.Username && m.Password == userlogin.Password).FirstOrDefault();
                string display;
                if (result != null)
                {
                    display = "Login Successful";
                }
                else
                {
                    result = _context.Logins.Where(m => m.Username == userlogin.Username).FirstOrDefault();
                    if (result != null)
                        display = "Incorrect Password"; //matches some user id, but password incorrect
                    else
                        display = "Incorrect Credentials";
                }
                return display;
            }
            else
            {
                return "entered Username or Password is empty";
            }
        }
    }
}
