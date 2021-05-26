using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ForumApi.Model;
using ForumApi.Interface;
using ForumApi.Services;

namespace ForumApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyPolicy")]
    public class LoginController : ControllerBase
    {
        public IUser userService_;
        public LoginController(IUser user)
        {
            userService_ = user;
        }

        [HttpGet("login/{userName}/{password}")]
        public User Login(string userName,string password)
        {
            
            return userService_.Login(userName,password);
        }

        [HttpPost("register")]
        public bool Register([FromBody] User user)
        {
            return userService_.Register(user);
        }
    }
}
