using Rental.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rental.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllCategoriesAsync();
        Task<IEnumerable<Category>> GetCategoriesByNameAsync(string name);
        Task<Category> GetCategoryByIdAsync(Guid id);
        Task <Category> AddCategoryAsync(Category category);
        Task <Category> UpdateCategoryAsync(Category category);
        Task <Category> DeleteCategoryAsync(Guid id);
    }
}
