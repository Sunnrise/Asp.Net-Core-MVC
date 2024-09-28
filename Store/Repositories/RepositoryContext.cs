using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
    public class RepositoryContext: DbContext
    {
        public DbSet<Product> Products {get;set;}
        public DbSet<Category>Categories{get;set;}

        public RepositoryContext(DbContextOptions<RepositoryContext>options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>()
            .HasData(
                new Product(){ ProductId=1, ProductName="Computer", Price=17000},
                new Product(){ ProductId=2, ProductName="Com", Price=1700},
                new Product(){ ProductId=3, ProductName="Comp", Price=170},
                new Product(){ ProductId=4, ProductName="Compu", Price=170},
                new Product(){ ProductId=5, ProductName="Comput", Price=17},
                new Product(){ ProductId=6, ProductName="Compute", Price=1}
            );

            modelBuilder.Entity<Category>()
            .HasData(
                new Category(){ CategoryId=1, CategoryName="Book"},
                new Category(){CategoryId=2, CategoryName="Electronic"}
            );
        }
    }
}