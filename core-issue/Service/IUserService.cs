using System.Collections.Generic;
using core_issue.model;

namespace core_issue.Service
{
    public interface IUserService
    {
        public List<User> GetUser();

        public User AddUser(User users);

        public User UpdateUser(string id, User users);

        public string DeleteUser(string id);
    }
}