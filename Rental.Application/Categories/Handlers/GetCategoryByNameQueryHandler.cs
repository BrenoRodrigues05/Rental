using MediatR;
using Rental.Application.Categories.Queries;
using Rental.Domain.Entities;
using Rental.Domain.Interfaces;

namespace Rental.Application.Categories.Handlers
{
    public class GetCategoryByNameQueryHandler : IRequestHandler<GetCategoryByNameQuery, 
        IEnumerable<Category>>
    {
        private readonly ICategoryRepository _categoryRepository;

        public GetCategoryByNameQueryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<Category>> Handle(GetCategoryByNameQuery request,
            CancellationToken cancellationToken)
        {
            var categories = await _categoryRepository.GetCategoriesByNameAsync(request.Name);
            return categories;
        }
    }
}
