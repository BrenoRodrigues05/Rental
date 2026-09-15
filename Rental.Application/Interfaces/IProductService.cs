using Rental.Application.DTOs;

namespace Rental.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetAllProductsAsync();
        Task<ProductDTO> GetProductByIdAsync(Guid id);
        Task<IEnumerable<ProductDTO>> GetProductsByCategoryAsync(Guid categoryId);
        Task<IEnumerable<ProductDTO>> GetProductsByNameAsync(string name);
        Task<ProductDTO> CreateProductAsync(ProductDTO productDto);
        Task<ProductDTO> UpdateProductAsync(ProductDTO productDto);
        Task<bool> DeleteProductAsync(Guid id);
    }
}
