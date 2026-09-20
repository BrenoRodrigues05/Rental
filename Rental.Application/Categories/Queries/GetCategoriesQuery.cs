using MediatR;
using Rental.Domain.Entities;

namespace Rental.Application.Categories.Queries
{
    public class GetCategoriesQuery : IRequest<IEnumerable<Category>>
    {
    }
}
