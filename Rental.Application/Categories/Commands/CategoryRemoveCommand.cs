using MediatR;
using Rental.Domain.Entities;

namespace Rental.Application.Categories.Commands
{
    public class CategoryRemoveCommand : IRequest<Category>
    {
        public Guid Id { get; set; }

        public CategoryRemoveCommand(Guid id)
        {
            Id = id;

        }
    }
}
