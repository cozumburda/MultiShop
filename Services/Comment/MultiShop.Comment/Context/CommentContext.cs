using Microsoft.EntityFrameworkCore;
using MultiShop.Comment.Entities;

namespace MultiShop.Comment.Context
{
    public class CommentContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1443;initial Catalog=MultiShopCommentDb;user=sa;password=123456aA*");
        }
        public DbSet<UserComment> UserComments { get; set; }
    }
}
