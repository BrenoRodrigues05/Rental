using MediatR;
using Rental.Application.Categories.Commands;
using Rental.Domain.Entities;
using Rental.Domain.Interfaces;

namespace Rental.Application.Categories.Handlers
{
    public class CategoryUpdateCommandHandler : IRequestHandler<CategoryUpdateCommand, Category>
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryUpdateCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Category> Handle(CategoryUpdateCommand request, CancellationToken cancellationToken)
        {
           var category = await _categoryRepository.GetCategoryByIdAsync(request.Id);
            if (category == null)
            {
                throw new ApplicationException($"Category with Id {request.Id} not found.");
            }
            category.Update(request.Name);
            return await _categoryRepository.UpdateCategoryAsync(category);
        }
    }
}
