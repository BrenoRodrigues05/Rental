using MediatR;
using Rental.Domain.Entities;

namespace Rental.Application.Products.Queries
{
    public class GetProductsByNameQuery : IRequest<IEnumerable<Product>>
    {
        public string Name { get; set; }
        public GetProductsByNameQuery(string name)
        {
            Name = name;
        }
    }
}
