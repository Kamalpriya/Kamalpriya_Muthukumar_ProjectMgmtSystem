using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectMgmtSystem.Models;

namespace ProjectMgmtSystem.Controllers
{
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
            var result = LoginData().Where(m => m.Username == userlogin.Username && m.Password == userlogin.Password).FirstOrDefault();
            string display;
            if(result != null)
            {
                display = "login successful";
            }
            else
            {
                result = LoginData().Where(m => m.Username == userlogin.Username).FirstOrDefault();
                if (result != null)
                    display = "incorrect password"; //matches some user id, but password incorrect
                else
                    display = "incorrect credentials";
            }
            return display;
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
