using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMgmtSystem.Models.UserModel
{
    public interface IUserRepository
    {
        public User CreateUser(User user);
        public User UpdateUser(int id, User user);
        public List<User> GetAllUsers();
        public User GetUserById(int id);
        public string DeleteUser(int id);
    }
}
