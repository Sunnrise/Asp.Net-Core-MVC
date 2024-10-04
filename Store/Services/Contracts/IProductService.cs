using Entities.DTOs;
using Entities.Models;

namespace Services.Contracts
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProducts(bool trackChanges);
        Product? GetOneProduct(int id,bool trackChanges);
        void CreateProduct(ProductDTO_ForInsertion productDto);
        void UpdateOneProduct(Product product);
        void DeleteOneProduct(int id);
    }
}