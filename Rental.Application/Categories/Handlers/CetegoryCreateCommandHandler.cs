using MediatR;
using Rental.Application.Categories.Commands;
using Rental.Domain.Entities;
using Rental.Domain.Interfaces;

namespace Rental.Application.Categories.Handlers
{
    public class CetegoryCreateCommandHandler : IRequestHandler<CategoryCreateCommand, Category>
    {
        private readonly ICategoryRepository _categoryRepository;

        public CetegoryCreateCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Category> Handle(CategoryCreateCommand request, CancellationToken cancellationToken)
        {
            var newCategory = new Category(request.Name);

           return await _categoryRepository.AddCategoryAsync(newCategory);
        }
    }
}
