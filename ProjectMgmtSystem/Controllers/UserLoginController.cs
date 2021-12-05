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
                var result = LoginData().Where(m => m.Username == userlogin.Username && m.Password == userlogin.Password).FirstOrDefault();
                string display;
                if (result != null)
                {
                    display = "Login Successful";
                }
                else
                {
                    result = LoginData().Where(m => m.Username == userlogin.Username).FirstOrDefault();
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

        public List<UserLogin> LoginData()
        {
            List<UserLogin> loginData = new List<UserLogin>();
            loginData.Add(new UserLogin { Username = "JohnDoe", Password = "jd1234" });
            loginData.Add(new UserLogin { Username = "JohnSkeet", Password = "js5678" });
            loginData.Add(new UserLogin { Username = "MarkSeeman", Password = "ms1234" });
            loginData.Add(new UserLogin { Username = "BobMartin", Password = "bm5678" });
            return loginData;
        }
    }
}
