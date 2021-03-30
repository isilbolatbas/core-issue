using System.Collections.Generic;
using core_issue.model;

namespace core_issue.Service
{
    public class UserService : IUserService
    {
        
        private List<User> _users;
        public UserService()
        {
            _users = new List<User>();
        }
        public List<User> GetUser()
        {
            return _users;
        }

        public User AddUser(User users)
        {
            _users.Add(users);
            return users;
        }

        public User UpdateUser(string id, User user)
        {
            for (var index = _users.Count - 1; index >= 0; index--)
            {
                if (_users[index].Id == id)
                {
                    _users[index] = user;
                }
            }
            return user;
        }

        public string DeleteUser(string id)
        {
            for (var index = _users.Count - 1; index >= 0; index--)
            {
                if (_users[index].Id == id)
                {
                    _users.RemoveAt(index);
                }
            }

            return id;
        }
    }
}