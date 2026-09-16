using MediatR;
using Rental.Application.Products.Commands;
using Rental.Domain.Entities;
using Rental.Domain.Interfaces;

namespace Rental.Application.Products.Handlers
{
    public class ProductRemoveCommandHandler : IRequestHandler<ProductRemoveCommand, Product>
    {
        private readonly IProductRepository _productRepository;
        public ProductRemoveCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<Product> Handle(ProductRemoveCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetProductByIdAsync(request.Id);
            if (product == null)
            {
                throw new ApplicationException($"Product with ID {request.Id} not found.");
            }
            else
            {
                var result = await _productRepository.DeleteProductAsync(product.Id);
                return result;
            }
        }
    }
}
