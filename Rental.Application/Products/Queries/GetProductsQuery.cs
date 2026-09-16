using MediatR;
using Rental.Domain.Entities;

namespace Rental.Application.Products.Queries
{
    public class GetProductsQuery : IRequest<IEnumerable<Product>>
    {
    }
}
