using MediatR;
using Rental.Domain.Entities;

namespace Rental.Application.Products.Queries
{
    public class GetProductsByCategoryIdQuery : IRequest<IEnumerable<Product>>
    {
        public Guid CategoryId { get; }

        public GetProductsByCategoryIdQuery(Guid categoryId)
        {
            CategoryId = categoryId;
        }
    }
}
