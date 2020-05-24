using Microsoft.EntityFrameworkCore;
using PandaApp.Models;

namespace PandaApp
{
    public class ApplicationDbContext :  DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Package> Packages { get; set; }

        public DbSet<Receipt> Receipts { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(@"Server=(LocalDb)\MSSQLLocalDB;Database=PandaApp;trusted_connection=true");
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
