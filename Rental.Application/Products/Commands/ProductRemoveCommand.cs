using MediatR;
using Rental.Domain.Entities;

namespace Rental.Application.Products.Commands
{
    public class ProductRemoveCommand : IRequest<Product>
    {
        public Guid Id { get; set; }
        public ProductRemoveCommand(Guid id)
        {
            Id = id;
        }
    }
}
