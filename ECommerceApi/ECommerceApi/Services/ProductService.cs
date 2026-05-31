using ECommerceApi.Data;
using ECommerceApi.Entities;
using ECommerceApi.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ECommerceApi.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly ECommerceDbContext _context;

        public ProductService(
            IProductRepository repository,
            ECommerceDbContext context)
        {
            _repository = repository;
            _context = context;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Product> AddAsync(Product product)
        {
            return await _repository.AddAsync(product);
        }

        public async Task UpdateAsync(Product product)
        {
            await _repository.UpdateAsync(product);
        }

        public async Task DeleteAsync(Product product)
        {
            await _repository.DeleteAsync(product);
        }

        public async Task<bool> CategoryExistsAsync(int categoryId)
        {
            return await _context.Categories
                .AnyAsync(x => x.Id == categoryId);
        }

        public async Task<List<Product>> SearchAsync(string search)
        {
            return await _repository.SearchAsync(search);
        }
    }
}