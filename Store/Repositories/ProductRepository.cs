using Entities.Models;
using Entities.RequestParameters;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Repositories.Extensions;

namespace Repositories
{
    public sealed class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateOneProduct(Product product)=> Create(product);

        public void DeleteOneProduct(Product product)=> Remove(product);

        
        public IQueryable<Product> GetAllProducts(bool trackChanges) => FindAll(trackChanges);

        public IQueryable<Product> GetAllProductsWithDetail(ProductRequestParameters p)
        {
            //after extension
            return _context
                .Products
                .FilteredByCategoryId(p.CategoryId)
                .FilteredBySearchTerm(p.SearchTerm)
                .FilteredByPrice(p.MinPrice,p.MaxPrice,p.IsValidPrice)
                .ToPaginate(p.PageNumber,p.PageSize);

            ////before extension
            
            // return p.CategoryId is null
            //     ?_context
            //         .Products
            //         .Include(prd=>prd.Category)
            //     :_context
            //         .Products
            //         .Include(prd=>prd.Category)
            //         .Where(prd=>prd.CategoryId.Equals(p.CategoryId));

        }

        //interfaces

        public Product? GetOneProduct(int id, bool trackChanges)
        {
            return FindByCondition(p=> p.ProductId.Equals(id),trackChanges);
        }

        public IQueryable<Product> GetShowCaseProducts(bool trackChanges)
        {
            return FindAll(trackChanges).Where(p=>p.ShowCase.Equals(true));
        }

        public void UpdateOneProduct(Product entity)=> Update(entity);
    }
}