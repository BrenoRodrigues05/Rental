using Microsoft.EntityFrameworkCore;
using Rental.Domain.Entities;
using Rental.Domain.Interfaces;
using Rental.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rental.Infra.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context)
        {
             _context = context;
        }
        public async Task<Category> AddCategoryAsync(Category category)
        {
           _context.Categories.Add(category);
              await _context.SaveChangesAsync();
                return category;
        }

        public async Task<Category?> DeleteCategoryAsync(Guid id)
        {
           var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return null;
            }
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
           return await _context.Categories
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<Category>> GetCategoriesByNameAsync(string name)
        {
            return await _context.Categories
                .AsNoTracking()
                .Where(c => c.Name.Contains(name))
                .ToListAsync();
        }

        public async Task<Category?> GetCategoryByIdAsync(Guid id)
        {
           return await _context.Categories
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Category> UpdateCategoryAsync(Category category)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
            return category;
        }
    }
}
