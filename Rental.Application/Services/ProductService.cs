using AutoMapper;
using Rental.Application.DTOs;
using Rental.Application.Interfaces;
using Rental.Domain.Entities;
using Rental.Domain.Interfaces;

namespace Rental.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ProductDTO> CreateProductAsync(ProductDTO productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            await _productRepository.AddProductAsync(product);
            return _mapper.Map<ProductDTO>(product);
        }

        public async Task<bool> DeleteProductAsync(Guid id)
        {
            var product = await _productRepository.GetProductByIdAsync(id);
            if (product == null)
            {
                return false;
            }
            await _productRepository.DeleteProductAsync(id);
            return true;
        }

        public async Task<IEnumerable<ProductDTO>> GetAllProductsAsync()
        {
            var products = await _productRepository.GetAllProductsAsync();
            return _mapper.Map<IEnumerable<ProductDTO>>(products);
        }

        public async Task<ProductDTO> GetProductByIdAsync(Guid id)
        {
            var product = await _productRepository.GetProductByIdAsync(id);
            return _mapper.Map<ProductDTO>(product);
        }

        public async Task<IEnumerable<ProductDTO>> GetProductsByCategoryAsync(Guid categoryId)
        {
           var products = await _productRepository.GetProductsByCategoryIdAsync(categoryId);
            return _mapper.Map<IEnumerable<ProductDTO>>(products);
        }

        public async Task<IEnumerable<ProductDTO>> GetProductsByNameAsync(string name)
        {
            var products = await _productRepository.GetProductsByNameAsync(name);
            return _mapper.Map<IEnumerable<ProductDTO>>(products);
        }

        public async Task<ProductDTO> UpdateProductAsync(ProductDTO productDto)
        {
           var product = _mapper.Map<Product>(productDto);
            await _productRepository.UpdateProductAsync(product);
            return _mapper.Map<ProductDTO>(product);
        }
    }
}
