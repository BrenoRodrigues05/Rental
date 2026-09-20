using MediatR;
using Rental.Domain.Entities;

namespace Rental.Application.Categories.Queries
{
    public class GetCategoryByNameQuery : IRequest<IEnumerable<Category>>
    {
        public string Name { get; set; }
        public GetCategoryByNameQuery(string name)
        {
            Name = name;
        }
    }
}
