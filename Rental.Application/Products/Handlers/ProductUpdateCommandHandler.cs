using MediatR;
using Rental.Application.Products.Commands;
using Rental.Domain.Entities;
using Rental.Domain.Interfaces;

namespace Rental.Application.Products.Handlers
{
    public class ProductUpdateCommandHandler : IRequestHandler<ProductUpdateCommand, Product>
    {
        private readonly IProductRepository _productRepository;

        public ProductUpdateCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> Handle(ProductUpdateCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetProductByIdAsync(request.Id);
            if (product == null)
            {
                throw new ApplicationException("Entity could not be found.");
            }
            else
            {
                product.Update(request.Name, request.Description, request.Price, request.Quantity, 
                               request.ImageUrl, request.CategoryId);

                return await _productRepository.UpdateProductAsync(product);
            }
            
        }
    }
}
