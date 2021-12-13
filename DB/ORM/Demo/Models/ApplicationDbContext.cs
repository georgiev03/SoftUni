using Microsoft.EntityFrameworkCore;

namespace Demo.Models
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.,1433;Database=CodeFirstDemo;User Id=sa;Password=Jorkata03;"); 
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<News> News { get; set; }
    }
}
