using AutoMapper;
using Entities.DTOs;
using Entities.Models;
using Entities.RequestParameters;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class ProductManager : IProductService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;



        public ProductManager(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public void CreateProduct(Product product)
        {
           
        }

        public void CreateProduct(ProductDTO_ForInsertion productDto)
        {
            Product product= _mapper.Map<Product>(productDto);
             _manager.Product.Create(product);
            _manager.Save();
        }

        public void DeleteOneProduct(int id)
        {
            Product product=GetOneProduct(id,false);
            if(product is not null)
            {
                _manager.Product.DeleteOneProduct(product);
                _manager.Save();
            }
        }

        public IEnumerable<Product> GetAllProducts(bool trackChanges)
        {
            return _manager.Product.GetAllProducts(trackChanges);
        }

        public IEnumerable<Product> GetAllProductsWithDetail(ProductRequestParameters p)
        {
            return _manager.Product.GetAllProductsWithDetail(p);
        }

        public Product? GetOneProduct(int id, bool trackChanges)
        {
            var product = _manager.Product.GetOneProduct(id, trackChanges);
            if (product is null)
            {
                throw new Exception("Product not found");
            }
            return product;
        }

        public ProductDTO_ForUpdate GetOneProductForUpdate(int id, bool trackChanges)
        {
            var product= GetOneProduct(id,trackChanges);
            var productDto = _mapper.Map<ProductDTO_ForUpdate>(product);
            return productDto;
        }

        public IEnumerable<Product> GetShowCaseProducts(bool trackChanges)
        {
            var product=_manager.Product.GetShowCaseProducts(trackChanges);
            return product;
        }

        public void UpdateOneProduct(ProductDTO_ForUpdate productDto)
        {
            // var entity = _manager.Product.GetOneProduct(productDto.ProductId, true);
            // entity.ProductName=productDto.ProductName;
            // entity.Price=productDto.Price;
            // entity.CategoryId=productDto.CategoryId;
            var entity= _mapper.Map<Product>(productDto);
            _manager.Product.UpdateOneProduct(entity);
            _manager.Save();
        }
    }
}