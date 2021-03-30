using System.Collections.Generic;
using core_issue.model;
using core_issue.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace core_issue.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {

       
        private ILogger _logger;
        private IUserService _service;

        
        public UserController(ILogger<UserController> logger, IUserService service)
        {
            _logger = logger;
            _service = service;
            
        }

        [HttpGet("/api/user")]
        public ActionResult<List<User>> GetUser()
        {
            return _service.GetUser();
        }

        [HttpPost("/api/user")]
        public ActionResult<User> AddUser(User user)
        {
            _service.AddUser(user);
            return user;
           
        }

        [HttpPut("/api/user/{id}")]
        public ActionResult<User> UpdateUser(string id, User user)
        {
            
            _service.UpdateUser(id, user);
            return user;
       
        }

        [HttpDelete("/api/products/{id}")]
        public ActionResult<string> DeleteUser(string id)
        {
            _service.DeleteUser(id);
            return id;
        }
    }
}