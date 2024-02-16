using Bulky.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace Bulky.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                // records to be inserted into db
                new Category() { Id = 1, Name = "Action", DisplayOrder = 1 },
                new Category() { Id = 2, Name = "SciFy", DisplayOrder = 2 },
                new Category() { Id = 3, Name = "Romatic", DisplayOrder = 3 }
                );
            modelBuilder.Entity<Product>().HasData(
                // records to be inserted into db
                new Product() { Id = 1, Author = "Alex", Title = "ML book", ISBN = "12345",CategoryId=1 },
                new Product() { Id = 2, Author = "James", Title = "DS book", ISBN = "01234", CategoryId = 1 }
                );
        }
    }
}
