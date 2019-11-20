using ECommerce.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerce.Core.Abstractions
{
    public interface IProductsService
    {
        Task<IEnumerable<Product>> GetAllProducts();

        Task<Product> GetProduct(int id);

        Task AddProduct(Product product);

        Task UpdateProduct(Product product);

        Task<bool> ProductExists(int id);

        Task DeleteProduct(Product product);
    }
}
