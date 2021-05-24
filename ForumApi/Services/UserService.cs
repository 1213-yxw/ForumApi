using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumApi.Services
{
    using ForumApi.Interface;
    using ForumApi.Model;
    public class UserService : IUser
    {
        public ForumDbContext dbContext_;
        public UserService(ForumDbContext db)
        {
            dbContext_ = db;
        }
        public bool Login(string userName, string password)
        {
            var user = (from u in dbContext_.Users
                        where u.UserName == userName && u.Password == password
                        select u).FirstOrDefault();
            if (user == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool Register(User user)
        {
            var item = (from u in dbContext_.Users
                        where u.UserName == user.UserName && u.Password == user.Password
                        select u).FirstOrDefault();
            if (item == null)
            {
                dbContext_.Users.Add(user);
                return dbContext_.SaveChanges()>0;
            }
            else
            {
                return false;
            }
        }
    }
}
