using MediatR;
using Rental.Application.Products.Queries;
using Rental.Domain.Entities;
using Rental.Domain.Interfaces;

namespace Rental.Application.Products.Handlers
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, IEnumerable<Product>>
    {
        private readonly IProductRepository _productRepository;

        public GetProductsQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> Handle(GetProductsQuery request, 
            CancellationToken cancellationToken)
        {
           return await _productRepository.GetAllProductsAsync();
        }
    }
}
