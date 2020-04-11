using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UserManagement.Models;
using UserManagement.Services;

namespace UserManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {

        private readonly ILogger<UserController> logger;
        private readonly IUserService userService;

        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            this.logger = logger;
            this.userService = userService;
        }


        [HttpGet("{Id}")]
        public User getUserDetails(string Id)
        {
            int userId = Convert.ToInt32(Id);
            var user = this.userService.getUserDetails(userId);
            if (user != null)
                return user;
            return new User();

        }
    }
}
