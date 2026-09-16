using MediatR;
using Rental.Application.Products.Commands;
using Rental.Domain.Entities;
using Rental.Domain.Interfaces;

namespace Rental.Application.Products.Handlers
{
    public class ProductCreateCommandHandler : IRequestHandler<ProductCreateCommand, Product>
    {
        private readonly IProductRepository _productRepository;

        public ProductCreateCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> Handle(ProductCreateCommand request, CancellationToken cancellationToken)
        {
            var newProduct = new Product(request.Name, request.Description, request.Price,
                                        request.Quantity, request.ImageUrl);

            if(newProduct == null)
            {
               throw new ApplicationException("Product could not be created.");
            }
            else
            {
                newProduct.CategoryId = request.CategoryId;
                return await _productRepository.AddProductAsync(newProduct);
            }
        }
    }
}
