using MediatR;
using Rental.Application.Categories.Queries;
using Rental.Domain.Entities;
using Rental.Domain.Interfaces;

namespace Rental.Application.Categories.Handlers
{
    public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, IEnumerable<Category>>
    {
        private readonly ICategoryRepository _categoryRepository;

        public GetCategoriesQueryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<Category>> Handle(GetCategoriesQuery request, CancellationToken 
            cancellationToken)
        {
            return await _categoryRepository.GetAllCategoriesAsync();
        }
    }
}
