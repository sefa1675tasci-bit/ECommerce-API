using Microsoft.EntityFrameworkCore;
using ECommerceApi.Data;
using ECommerceApi.Entities;

namespace ECommerceApi.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ECommerceDbContext _context;

        public ProductRepository(ECommerceDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _context.Products
                .Include(x => x.Category)
                .ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _context.Products
                .Include(x => x.Category)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Product> AddAsync(Product product)
        {
            _context.Products.Add(product);

            await _context.SaveChangesAsync();

            return product;
        }

        public async Task UpdateAsync(Product product)
        {
            _context.Products.Update(product);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Product product)
        {
            _context.Products.Remove(product);

            await _context.SaveChangesAsync();
        }

        public async Task<List<Product>> SearchAsync(string search)
        {

            return await _context.Products
                .Include(x => x.Category)
                .Where(x => x.Name.ToLower().Contains(search.ToLower()))
                .ToListAsync();
        }
    }
}