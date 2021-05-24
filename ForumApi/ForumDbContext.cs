using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumApi
{
    using Microsoft.EntityFrameworkCore;
    using ForumApi.Model;
    public class ForumDbContext:DbContext
    {
        public ForumDbContext(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Menu>().HasData(
               new Menu
               {
                   Id = 1,
                   Text = "全部帖子",
                   Url = "/personalCenter/postAll"
               },
               new Menu
               {
                   Id = 2,
                   Text = "创建帖子",
                   Url = "/personalCenter/richText"
               }
           );
        }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Menu> Menus{ get; set; }

    }
}
