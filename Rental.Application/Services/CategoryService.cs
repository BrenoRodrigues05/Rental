using AutoMapper;
using MediatR;
using Rental.Application.Categories.Commands;
using Rental.Application.Categories.Queries;
using Rental.Application.DTOs;
using Rental.Application.Interfaces;

namespace Rental.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CategoryService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<CategoryDTO> CreateCategoryAsync(CategoryDTO categoryDto)
        {
            var categoryCreateCommand = _mapper.Map<CategoryCreateCommand>(categoryDto);
            var category = await _mediator.Send(categoryCreateCommand);
            return _mapper.Map<CategoryDTO>(category);
        }

        public async Task<bool> DeleteCategoryAsync(Guid id)
        {
            var categoryRemoveCommand = new CategoryRemoveCommand(id);
            await _mediator.Send(categoryRemoveCommand);
            return true;
        }

        public async Task<IEnumerable<CategoryDTO>> GetAllCategoriesAsync()
        {
            var categoryGetAllQuery = new GetCategoriesQuery();
            var categories = await _mediator.Send(categoryGetAllQuery);
            return _mapper.Map<IEnumerable<CategoryDTO>>(categories);

        }

        public async Task<IEnumerable<CategoryDTO>> GetCategoriesByNameAsync(string name)
        {
            var categoryGetByNameQuery = new GetCategoryByNameQuery(name);
            var categories = await _mediator.Send(categoryGetByNameQuery);
            return _mapper.Map<IEnumerable<CategoryDTO>>(categories);
        }

        public async Task<CategoryDTO> GetCategoryByIdAsync(Guid id)
        {
            var categoryGetByIdQuery = new GetCategoryByIdQuery(id);
            var category = await _mediator.Send(categoryGetByIdQuery);
            return _mapper.Map<CategoryDTO>(category);
        }

        public async Task<CategoryDTO> UpdateCategoryAsync(CategoryDTO categoryDto)
        {
            var categoryUpdateCommand = _mapper.Map<CategoryUpdateCommand>(categoryDto);
            var updatedCategory = await _mediator.Send(categoryUpdateCommand);
            return _mapper.Map<CategoryDTO>(updatedCategory);
        }
    }
}
