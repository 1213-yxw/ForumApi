using ForumApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumApi.Interface
{
    public interface IMenu
    {
        abstract List<Menu> GetMenus();
    }
}
