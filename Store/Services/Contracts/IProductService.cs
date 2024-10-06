using Entities.DTOs;
using Entities.Models;

namespace Services.Contracts
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProducts(bool trackChanges);
        IEnumerable<Product> GetShowCaseProducts(bool trackChanges);

        Product? GetOneProduct(int id,bool trackChanges);
        void CreateProduct(ProductDTO_ForInsertion productDto);
        void UpdateOneProduct(ProductDTO_ForUpdate product);
        void DeleteOneProduct(int id);
        ProductDTO_ForUpdate GetOneProductForUpdate(int id, bool trackChanges);
    }
}