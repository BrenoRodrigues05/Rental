using MediatR;
using Rental.Application.Products.Queries;
using Rental.Domain.Entities;
using Rental.Domain.Interfaces;

namespace Rental.Application.Products.Handlers
{
    public class GetProductsByCategoryIdQueryHandler : IRequestHandler<GetProductsByCategoryIdQuery, 
        IEnumerable<Product>>
    {
        private readonly IProductRepository _productRepository;

        public GetProductsByCategoryIdQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> Handle(GetProductsByCategoryIdQuery request,
            CancellationToken cancellationToken)
        {
           var products = await _productRepository.GetProductsByCategoryIdAsync(request.CategoryId);
    
            return products;
        }
    }
}
