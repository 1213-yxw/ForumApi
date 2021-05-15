using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumApi.Model
{
    public class User
    {//普通用户类
        public virtual int Id { get; set; }
        public virtual string UserName { get; set; }//用户名
        public virtual string Password { get; set; }//密码
        public virtual string Avatar { get; set; }//头像
    }
}
