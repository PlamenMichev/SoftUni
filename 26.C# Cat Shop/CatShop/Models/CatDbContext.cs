namespace CatShop.Models
{
    using Microsoft.EntityFrameworkCore;

    public class CatDbContext : DbContext
    {
        public DbSet<Cat> Cats { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=Cats;Trusted_Connection=True;");
        }
    }
}
