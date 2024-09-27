using Microsoft.EntityFrameworkCore;
using Entities.Models;

namespace StoreApp.Models
{
    public class RepositoryContext: DbContext
    {
        public DbSet<Product> Products {get;set;}

        public RepositoryContext(DbContextOptions<RepositoryContext>options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>()
            .HasData(
                new Product(){ Id=1, ProductName="Computer", Price=17000},
                new Product(){ Id=2, ProductName="Com", Price=1700},
                new Product(){ Id=3, ProductName="Comp", Price=170},
                new Product(){ Id=4, ProductName="Compu", Price=170},
                new Product(){ Id=5, ProductName="Comput", Price=17},
                new Product(){ Id=6, ProductName="Compute", Price=1}
            );
        }
    }

}