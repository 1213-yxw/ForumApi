using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ForumApi.Model;
using ForumApi.Interface;
using Microsoft.AspNetCore.Cors;

namespace ForumApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyPolicy")]
    public class UserController : ControllerBase
    {
        public IUser userService_;
        public UserController(IUser user)
        {
            userService_ = user;
        }

        [HttpPost("addUser")]
        public bool AddUser([FromBody]User user)
        {
            if (user == null)
            {
                return false;
            }
            else
            {
               return userService_.AddUser(user);
            }
        }

        [HttpPost("updateUser")]
        public bool UpdateUser([FromBody] User user)
        {
            if (user == null)
            {
                return false;
            }
            else
            {
                return userService_.UpdateUser(user);
            }
        }

        [HttpGet("deleteUser/{nid:int}")]
        public bool DeleteUser([FromRoute] int? nid)
        {
            if (nid == null) { return false; }
            else
            {
                return userService_.DeleteUser(nid.Value);
            }
        }

        [HttpGet("updateAvatar/{nid:int}/{avatar}")]
        public bool UpdateAvatar([FromRoute]int? nid,string avatar)
        {
            if (nid==null&&avatar == null) { return false; }
            else
            {
                return userService_.UpdateAvatar(nid.Value,avatar);
            }
        }
    }
}
