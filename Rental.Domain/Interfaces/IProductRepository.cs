using Rental.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rental.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<IEnumerable<Product>> GetProductsByCategoryIdAsync(Guid categoryId);
        Task<IEnumerable<Product>> GetProductsByNameAsync(string name);
        Task<Product> GetProductByIdAsync(Guid id);
        Task <Product> AddProductAsync(Product product);
        Task <Product> UpdateProductAsync(Product product);
        Task <Product> DeleteProductAsync(Guid id);

    }
}
