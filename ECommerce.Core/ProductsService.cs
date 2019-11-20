using ECommerce.Core.Abstractions;
using ECommerce.DataAccess.Abstraction;
using ECommerce.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerce.Core
{
    public class ProductsService : IProductsService
    {
        private readonly IRepository<Product> _productsRepository;

        public ProductsService(IRepository<Product> repo)
        {
            _productsRepository = repo;
        }

        public Task AddProduct(Product product)
        {
            return _productsRepository.Add(product);
        }

        public Task DeleteProduct(Product product)
        {
            return _productsRepository.Remove(product);
        }

        public Task<IEnumerable<Product>> GetAllProducts()
        {
            //TODO: Change Product into Product Model
            return _productsRepository.GetAll();
        }

        public Task<Product> GetProduct(int id)
        {
            return _productsRepository.GetById(id);
        }

        public Task<bool> ProductExists(int id)
        {
            var result = _productsRepository.GetById(id);
            return Task.FromResult<bool>(result != null);
        }

        public Task UpdateProduct(Product product)
        {
            return _productsRepository.Update(product);
        }
    }
}
