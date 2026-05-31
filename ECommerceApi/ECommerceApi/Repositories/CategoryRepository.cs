using ECommerceApi.Data;
using ECommerceApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerceApi.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ECommerceDbContext _context;

        public CategoryRepository(ECommerceDbContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category?> GetByIdAsync(int id)
        {
            return await _context.Categories
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Category> AddAsync(Category category)
        {
            _context.Categories.Add(category);

            await _context.SaveChangesAsync();

            return category;
        }

        public async Task UpdateAsync(Category category)
        {
            _context.Categories.Update(category);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Category category)
        {
            _context.Categories.Remove(category);

            await _context.SaveChangesAsync();
        }
    }
}