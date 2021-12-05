using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMgmtSystem.Models.UserModel
{
    // 2b. User service with CRUD api implementations
    public class UserService : IUserRepository
    {
        private static List<User> Users;
        private static int cnt = 4;

        public UserService()
        {
            Users = new List<User>()
            {
                new User(){Id=1, FirstName="John", LastName="Doe", Email="john.doe@test.com", Password="jd1234"},
                new User(){Id=2, FirstName="John", LastName="Skeet", Email="john.skeet@test.com", Password="js5678"},
                new User(){Id=3, FirstName="Mark", LastName="Seeman", Email="mark.seeman@test.com", Password="ms1234"},
                new User(){Id=4, FirstName="Bob", LastName="Martin", Email="bob.martin@test.com", Password="bm5678"}
            };
        }
        public User CreateUser(User user)
        {
            user.Id = ++cnt;
            Users.Add(user);
            return user;
        }

        public string DeleteUser(int id)
        {
            User user = GetUserById(id);
            Users.Remove(user);
            cnt--;
            return "user deleted";
        }

        public List<User> GetAllUsers()
        {
            return Users;
        }

        public User GetUserById(int id)
        {
            foreach (var user in Users)
            {
                if(user.Id == id)
                {
                    return user;
                }
            }
            return null;
        }

        public User UpdateUser(int id, User inpUser)
        {
            User user = GetUserById(id);
            Users.Remove(user);  // remove user at the id
            Users.Add(inpUser);  // insert updated user at end of list 
            return GetUserById(inpUser.Id);
        }
    }
}
