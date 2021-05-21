using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumApi.Services
{
    using ForumApi.Interface;
    using ForumApi.Model;
    public class MenuService : IMenu
    {
        public ForumDbContext dbContext_;
        public MenuService(ForumDbContext db)
        {
            dbContext_ = db;
        }
        public List<Menu> GetMenus()
        {
            var menus = dbContext_.Menus.ToList();
            return LoadMenus(menus);
        }
        private List<Menu> LoadMenus(List<Menu> menus)
        {
            List<Menu> result = new List<Menu>();
            menus.ForEach(m =>
            {
                Menu item = new Menu
                {
                    Id = m.Id,
                    Url = m.Url,
                    Text = m.Text
                };
                result.Add(item);
            });
            return result;
        }
    }
}
