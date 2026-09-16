using MediatR;
using Rental.Domain.Entities;

namespace Rental.Application.Products.Queries
{
    public class GetProductByIdQuery : IRequest<Product>
    {
        public Guid Id { get; set; }
        public GetProductByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
