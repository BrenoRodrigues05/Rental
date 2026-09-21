using AutoMapper;
using MediatR;
using Rental.Application.DTOs;
using Rental.Application.Interfaces;
using Rental.Application.Products.Commands;
using Rental.Application.Products.Queries;

namespace Rental.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ProductService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<ProductDTO> CreateProductAsync(ProductDTO productDto)
        {
            var productCreateCommand = _mapper.Map<ProductCreateCommand>(productDto);
            var product = await _mediator.Send(productCreateCommand);
            return _mapper.Map<ProductDTO>(product);
        }

        public async Task<bool> DeleteProductAsync(Guid id)
        {
            var deleteProductCommand = new ProductRemoveCommand(id);
            await _mediator.Send(deleteProductCommand);
            return true;
        }

        public async Task<IEnumerable<ProductDTO>> GetAllProductsAsync()
        {
            var productsGetAllQuery = new GetProductsQuery();
            var products = await _mediator.Send(productsGetAllQuery);
            return _mapper.Map<IEnumerable<ProductDTO>>(products);
        }

        public async Task<ProductDTO> GetProductByIdAsync(Guid id)
        {
            var productGetByIdQuery = new GetProductByIdQuery(id);
            var product = await _mediator.Send(productGetByIdQuery);
            return _mapper.Map<ProductDTO>(product);
        }

        public async Task<IEnumerable<ProductDTO>> GetProductsByCategoryAsync(Guid categoryId)
        {
            var products = new GetProductsByCategoryIdQuery(categoryId);
            var productsByCategory = await _mediator.Send(products);
            return _mapper.Map<IEnumerable<ProductDTO>>(productsByCategory);
        }

        public async Task<IEnumerable<ProductDTO>> GetProductsByNameAsync(string name)
        {
            var products = new GetProductsByNameQuery(name);
            var productsByName = await _mediator.Send(products);
            return _mapper.Map<IEnumerable<ProductDTO>>(productsByName);
        }

        public async Task<ProductDTO> UpdateProductAsync(ProductDTO productDto)
        {
            var productUpdateCommand = _mapper.Map<ProductUpdateCommand>(productDto);
            var product = await _mediator.Send(productUpdateCommand);
            return _mapper.Map<ProductDTO>(product);
        }
    }
}
