using AutoMapper;
using Rental.Application.DTOs;
using Rental.Application.Interfaces;
using Rental.Domain.Entities;
using Rental.Domain.Interfaces;

namespace Rental.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CategoryDTO> CreateCategoryAsync(CategoryDTO categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);
            await _categoryRepository.AddCategoryAsync(category);
            return _mapper.Map<CategoryDTO>(category);
        }

        public async Task<bool> DeleteCategoryAsync(Guid id)
        {
            await _categoryRepository.DeleteCategoryAsync(id);
            return true;
        }

        public async Task<IEnumerable<CategoryDTO>> GetAllCategoriesAsync()
        {
            var categories = await _categoryRepository.GetAllCategoriesAsync();
            return _mapper.Map<IEnumerable<CategoryDTO>>(categories);

        }

        public async Task<IEnumerable<CategoryDTO>> GetCategoriesByNameAsync(string name)
        {
            var categories = await _categoryRepository.GetCategoriesByNameAsync(name);
            return _mapper.Map<IEnumerable<CategoryDTO>>(categories);
        }

        public async Task<CategoryDTO> GetCategoryByIdAsync(Guid id)
        {
           var category = await _categoryRepository.GetCategoryByIdAsync(id);
            if(category == null)
            {
                throw new KeyNotFoundException($"Category with id: {id} not found");
            }
            return _mapper.Map<CategoryDTO>(category);
        }

        public async Task<CategoryDTO> UpdateCategoryAsync(CategoryDTO categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);
            await _categoryRepository.UpdateCategoryAsync(category);
            return _mapper.Map<CategoryDTO>(category);
        }
    }
}
