using Rental.Application.DTOs;

namespace Rental.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDTO>> GetAllCategoriesAsync();
        Task<CategoryDTO> GetCategoryByIdAsync(Guid id);

        Task<IEnumerable<CategoryDTO>> GetCategoriesByNameAsync(string name);

        Task<CategoryDTO> CreateCategoryAsync(CategoryDTO categoryDto);

        Task<CategoryDTO> UpdateCategoryAsync(CategoryDTO categoryDto);

        Task<bool> DeleteCategoryAsync(Guid id);
    }
}
