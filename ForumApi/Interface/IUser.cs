using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumApi.Interface
{
    using ForumApi.Model;
    public interface IUser
    {
       User Login(string userName, string password);
       bool Register(User user);
       bool AddUser(User user);
       bool UpdateUser(User user);
       bool DeleteUser(int id);
       bool UpdateAvatar(int id,string avatar);
    }
}
