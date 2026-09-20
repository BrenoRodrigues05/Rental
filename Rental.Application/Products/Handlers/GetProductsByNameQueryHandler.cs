using MediatR;
using Rental.Application.Products.Queries;
using Rental.Domain.Entities;
using Rental.Domain.Interfaces;

namespace Rental.Application.Products.Handlers
{
    public class GetProductsByNameQueryHandler : IRequestHandler<GetProductsByNameQuery, 
        IEnumerable<Product>>
    {
        private readonly IProductRepository _productRepository;

        public GetProductsByNameQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> Handle(GetProductsByNameQuery request, 
            CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetProductsByNameAsync(request.Name);

            return products;
        }
    }
}
