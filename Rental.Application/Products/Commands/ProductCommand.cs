using MediatR;
using Rental.Domain.Entities;

namespace Rental.Application.Products.Commands
{
    public abstract class ProductCommand : IRequest<Product>
    {
        public string Name { get;  set; }
        public string Description { get;  set; }
        public decimal Price { get;  set; }
        public int Quantity { get;  set; }
        public string ImageUrl { get;  set; }
        public Guid CategoryId { get; set; }
    }
}
