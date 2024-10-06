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
                new Product(){ ProductId=1, CategoryId=2,ImageUrl="/images/1.jpg", ProductName="Computer", Price=17000, ShowCase=false},
                new Product(){ ProductId=2, CategoryId=2,ImageUrl="/images/2.jpg", ProductName="Com", Price=1700, ShowCase=false},
                new Product(){ ProductId=3, CategoryId=2,ImageUrl="/images/3.jpg", ProductName="Comp", Price=170, ShowCase=false},
                new Product(){ ProductId=4, CategoryId=2,ImageUrl="/images/4.jpg", ProductName="Compu", Price=170, ShowCase=false},
                new Product(){ ProductId=5, CategoryId=2,ImageUrl="/images/5.jpg", ProductName="Comput", Price=17, ShowCase=false},
                new Product(){ ProductId=6, CategoryId=1,ImageUrl="/images/6.jpg", ProductName="Science Book", Price=1, ShowCase=false},
                new Product(){ ProductId=7, CategoryId=1,ImageUrl="/images/7.jpg", ProductName="Maths", Price=1445245, ShowCase=false},
                new Product(){ ProductId=8, CategoryId=1,ImageUrl="/images/8.jpg", ProductName="bio", Price=100, ShowCase=true},
                new Product(){ ProductId=9, CategoryId=1,ImageUrl="/images/9.jpg", ProductName="platon", Price=145, ShowCase=true},
                new Product(){ ProductId=10, CategoryId=1,ImageUrl="/images/10.jpg", ProductName="Maths", Price=142342, ShowCase=true}
            );
        }
    }
}