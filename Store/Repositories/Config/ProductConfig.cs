using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Config
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p=>p.ProductId);
            builder.Property(p=>p.ProductName).IsRequired();
            builder.Property(p=>p.Price).IsRequired();

            builder.HasData(
                new Product(){ ProductId=1, CategoryId=2, ProductName="Computer", Price=17000},
                new Product(){ ProductId=2, CategoryId=2, ProductName="Com", Price=1700},
                new Product(){ ProductId=3, CategoryId=2, ProductName="Comp", Price=170},
                new Product(){ ProductId=4, CategoryId=2, ProductName="Compu", Price=170},
                new Product(){ ProductId=5, CategoryId=2, ProductName="Comput", Price=17},
                new Product(){ ProductId=6, CategoryId=1, ProductName="Science Book", Price=1},
                new Product(){ ProductId=7, CategoryId=1, ProductName="Maths", Price=1}
            );
        }
    }
}