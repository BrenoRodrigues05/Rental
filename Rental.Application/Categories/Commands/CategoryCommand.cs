using MediatR;
using Rental.Domain.Entities;

namespace Rental.Application.Categories.Commands
{
    public abstract class CategoryCommand : IRequest<Category>
    {
        public string Name { get; set; }
    }
}
