using FinLit.Data.Interfaces;
using FinLit.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FinLit.Data.Repository
{
    public class CategoryRepository : ICategories
    {     
        private readonly DbContent dbContent;

        public CategoryRepository(DbContent dbContent)
        {
            this.dbContent = dbContent;
        }

        public async Task<IEnumerable<Category>> GetAllAsync() => await dbContent.Categories.ToListAsync();
        

        public async Task<IEnumerable<Category>> GetAllExpenseCategoriesAsync() =>
            await dbContent.Categories.Where(c => c.CategoryType.Equals("Expense")).ToListAsync();

        public async Task<IEnumerable<Category>> GetAllIncomeCategoriesAsync() =>
            await dbContent.Categories.Where(c => c.CategoryType.Equals("Income")).ToListAsync();

        public async Task AddAsync(Category category)
        {
            dbContent.Categories.Add(category);
            await dbContent.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var obj = await dbContent.Categories.FindAsync(id);

            if (obj != null)
            {
                dbContent.Categories.Remove(obj);
                await dbContent.SaveChangesAsync();
            }
        }
        public async Task<Category> GetByIdAsync(int id)
        {
            var category = await dbContent.Categories.FindAsync(id);

            if (category is null)
            {
                throw new KeyNotFoundException($"Category with id {id} not found.");
            }

            return category;
        }
    }
}
